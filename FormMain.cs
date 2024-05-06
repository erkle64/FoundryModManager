using BlueMystic;
using Narod;
using Narod.SteamGameFinder;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Text;

namespace FoundryModManager
{
    public partial class FormMain : Form
    {
        private RepositoryData.Entry[]? _repositories;
        private List<ModsConfiguration>? _modsConfigurations;
        private string? _dataFolderPath;
        private string? _cacheFolderPath;
        private string? _configFilePath;
        private int _currentSelectedConfiguration = -1;
        private bool _ignoreEvents = false;
        private string _textEditorPath = "";

        private DarkModeCS _darkMode;

        public FormMain()
        {
            InitializeComponent();

            _darkMode = new DarkModeCS(this);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            _dataFolderPath = Path.Combine(appdataPath, @"Erkle\FoundryModManager2024");
            if (!Directory.Exists(_dataFolderPath)) Directory.CreateDirectory(_dataFolderPath);

            _cacheFolderPath = Path.Combine(_dataFolderPath, @"Cache");
            if (!Directory.Exists(_cacheFolderPath)) Directory.CreateDirectory(_cacheFolderPath);

            var repositoriesLoaded = false;
            while (!repositoriesLoaded)
            {
                try
                {
                    LoadRepositories();
                    repositoriesLoaded = true;
                }
                catch (Exception ex)
                {
                    var result = MessageBox.Show($"Error: {ex.Message}", "Failed to load repositories", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result != DialogResult.Retry)
                    {
                        Application.Exit();
                        return;
                    }
                }
            }

            _modsConfigurations = new List<ModsConfiguration>
            {
                new ModsConfiguration("Vanilla", true, new string[0])
            };

            _configFilePath = Path.Combine(_dataFolderPath, @"configurations.json");
            if (File.Exists(_configFilePath))
            {
                var json = File.ReadAllText(_configFilePath);
                var data = JsonConvert.DeserializeObject<ConfigurationsData>(json);
                if (data != null)
                {
                    if (data.foundryFolder != null)
                    {
                        inputPath.Text = data.foundryFolder;
                    }

                    if (data.configurations != null)
                    {
                        foreach (var configuration in data.configurations)
                        {
                            _modsConfigurations.Add(new ModsConfiguration(configuration.name ?? "unnamed", false, configuration.enabledMods ?? new string[0]));
                        }

                        FillConfigurationsList();
                        SelectConfiguration(data.currentSelectedConfiguration ?? "Vanilla");
                    }
                }
            }
            else
            {
                _modsConfigurations.Add(new ModsConfiguration("Default", false, new string[0]));
                FillConfigurationsList();
                SelectConfiguration(1);
                SaveConfigurations();
            }

            if (string.IsNullOrEmpty(inputPath.Text))
            {
                var steamGameLocator = new SteamGameLocator();
                if (steamGameLocator.getIsSteamInstalled())
                {
                    var gameInfo = steamGameLocator.getGameInfoByFolder("FOUNDRY");
                    if (!string.IsNullOrEmpty(gameInfo.steamGameLocation))
                    {
                        inputPath.Text = gameInfo.steamGameLocation.Replace(@"\\", @"\");
                    }
                }
            }

            if (!TryGetTextEditorExecutable(out _textEditorPath))
            {
                buttonModConfig.Enabled = false;
            }
        }

        private void InstallCurrentConfiguration()
        {
            Debug.Assert(_cacheFolderPath != null);

            var exePath = Path.Combine(inputPath.Text, "Foundry.exe");
            if (!File.Exists(exePath))
            {
                MessageBox.Show(this, "Foundry.exe not found!");
                return;
            }

            var modsPath = Path.Combine(inputPath.Text, "Mods");
            if (!Directory.Exists(modsPath)) Directory.CreateDirectory(modsPath);

            using var httpClient = new HttpClient();

            Debug.Assert(_repositories != null);
            for (int modIndex = 0; modIndex < _repositories.Length; modIndex++)
            {
                if (IsModEnabled(modIndex))
                {
                    InstallMod(modIndex, modsPath, httpClient);
                }
                else
                {
                    UninstallMod(modIndex, modsPath);
                }
            }
        }

        private void UninstallMod(int modIndex, string modsPath)
        {
            Debug.Assert(_repositories != null);
            Debug.Assert(_repositories.Length > modIndex);
            Debug.Assert(_repositories[modIndex] != null);

            var folderName = _repositories[modIndex].folder ?? _repositories[modIndex].name;
            Debug.Assert(folderName != null);

            var modPath = Path.Combine(modsPath, folderName);
            if (Directory.Exists(modPath)) Directory.Delete(modPath, true);
        }

        private void InstallMod(int modIndex, string modsPath, HttpClient httpClient)
        {
            Debug.Assert(_cacheFolderPath != null);
            Debug.Assert(_repositories != null);
            Debug.Assert(_repositories.Length > modIndex);
            Debug.Assert(_repositories[modIndex] != null);

            var modURL = _repositories[modIndex].url;
            Debug.Assert(modURL != null);

            var modName = _repositories[modIndex].name;
            Debug.Assert(modName != null);

            var folderName = _repositories[modIndex].folder ?? modName;
            Debug.Assert(folderName != null);

            var modPath = Path.Combine(modsPath, folderName);
            if (!Directory.Exists(modsPath)) Directory.CreateDirectory(modPath);

            var cachedModFolderPath = Path.Combine(_cacheFolderPath, modName);
            if (!Directory.Exists(cachedModFolderPath)) Directory.CreateDirectory(cachedModFolderPath);

            var cachedModPath = Path.Combine(cachedModFolderPath, Path.GetFileName(modURL));
            var cachedModSourcePath = Path.Combine(cachedModFolderPath, "source.url");

            if (File.Exists(cachedModPath))
            {
                if (File.Exists(cachedModSourcePath))
                {
                    var sourceURL = File.ReadAllText(cachedModSourcePath);
                    if (sourceURL != modURL)
                    {
                        File.Delete(cachedModPath);
                        File.Delete(cachedModSourcePath);
                    }
                }
                else
                {
                    File.Delete(cachedModPath);
                }
            }

            if (!File.Exists(cachedModPath))
            {
                toolStripStatusLabel1.Text = $"Downloading {Path.GetFileName(modURL)}";
                statusStrip1.Refresh();
                var task = Task.Run(() => DownloadFile(httpClient, modURL, cachedModPath));
                task.Wait();
                toolStripStatusLabel1.Text = "";
                statusStrip1.Refresh();

                File.WriteAllText(cachedModSourcePath, modURL);
            }

            if (File.Exists(cachedModPath))
            {
                toolStripStatusLabel1.Text = $"Extracting {Path.GetFileName(modURL)}";
                statusStrip1.Refresh();
                ZipFile.ExtractToDirectory(cachedModPath, modPath, true);
                toolStripStatusLabel1.Text = "";
                statusStrip1.Refresh();
            }
        }

        private void LoadRepositories()
        {
            Debug.Assert(_cacheFolderPath != null);

            using (var httpClient = new HttpClient())
            {
                var task = Task.Run(() => httpClient.GetStringAsync("https://erkle64.github.io/FoundryModManager/sources.2024.json"));
                task.Wait(15000);
                if (!task.IsCompleted)
                {
                    throw new Exception("Timeout while waiting for repository data.");
                }
                if (task.IsCompletedSuccessfully)
                {
                    var json = task.Result;
                    var data = JsonConvert.DeserializeObject<SourcesData>(json);
                    if (data != null && data.sources != null)
                    {
                        var sources = data.sources;

                        var combinedRepositories = new List<RepositoryData.Entry>();
                        foreach (var source in sources)
                        {
                            var repositories = LoadRepositoriesFrom(source);
                            if (repositories != null)
                            {
                                combinedRepositories.AddRange(repositories);
                            }
                        }
                        _repositories = combinedRepositories.ToArray();

                        listMods.BeginUpdate();
                        listMods.Items.Clear();
                        foreach (var repository in _repositories)
                        {
                            if (repository.name != null)
                            {
                                listMods.Items.Add(repository);

                                var cachePath = Path.Combine(_cacheFolderPath, repository.name);
                                if (!Directory.Exists(cachePath)) Directory.CreateDirectory(cachePath);
                            }
                        }
                        listMods.EndUpdate();
                    }
                }
            }

            if (_repositories == null || _repositories.Length == 0)
            {
                throw new Exception("Repository data not found.");
            }
        }

        private RepositoryData.Entry[]? LoadRepositoriesFrom(string modDataURL)
        {
            Debug.Assert(_cacheFolderPath != null);

            using (var httpClient = new HttpClient())
            {
                var task = Task.Run(() => httpClient.GetStringAsync(modDataURL));
                task.Wait();
                if (task.IsCompletedSuccessfully)
                {
                    var json = task.Result;
                    var data = JsonConvert.DeserializeObject<RepositoryData>(json);
                    if (data != null && data.repositories != null)
                    {
                        return data.repositories;
                    }
                }
            }

            return null;
        }

        private void FillConfigurationsList()
        {
            Debug.Assert(_modsConfigurations != null);

            listConfigurations.BeginUpdate();
            listConfigurations.Items.Clear();
            foreach (var configuration in _modsConfigurations)
            {
                listConfigurations.Items.Add(configuration.name);
            }
            listConfigurations.EndUpdate();
        }

        private void SelectConfiguration(string configurationName)
        {
            Debug.Assert(_modsConfigurations != null);

            for (int configurationIndex = 0; configurationIndex < _modsConfigurations.Count; configurationIndex++)
            {
                var modConfiguration = _modsConfigurations[configurationIndex];
                if (modConfiguration?.name == configurationName)
                {
                    SelectConfiguration(configurationIndex);
                    return;
                }
            }

            SelectConfiguration(0);
        }

        private void SelectConfiguration(int configurationIndex)
        {
            if (_currentSelectedConfiguration == configurationIndex) return;
            _currentSelectedConfiguration = configurationIndex;

            Debug.Assert(_modsConfigurations != null);

            _ignoreEvents = true;
            listConfigurations.SelectedIndex = configurationIndex;
            _ignoreEvents = false;
            ApplyCurrentConfiguration();
            SaveConfigurations();
        }

        private void ApplyCurrentConfiguration()
        {
            Debug.Assert(_repositories != null);
            Debug.Assert(_modsConfigurations != null);
            Debug.Assert(_modsConfigurations.Count > _currentSelectedConfiguration);

            var currentConfiguration = _modsConfigurations[_currentSelectedConfiguration];
            Debug.Assert(currentConfiguration != null);

            for (int modIndex = 0; modIndex < _repositories.Length; modIndex++)
            {
                RepositoryData.Entry? repository = _repositories[modIndex];
                if (repository != null && repository.name != null)
                {
                    _ignoreEvents = true;
                    listMods.SetItemChecked(modIndex, currentConfiguration.IsModEnabled(repository.name));
                    _ignoreEvents = false;
                }
            }
        }

        private void SaveConfigurations()
        {
            Debug.Assert(_configFilePath != null);
            Debug.Assert(_modsConfigurations != null);

            var entries = new List<ConfigurationsData.Entry>(_modsConfigurations.Count - 1);
            foreach (var modsConfiguration in _modsConfigurations)
            {
                if (!modsConfiguration.isVanilla)
                {
                    var entry = modsConfiguration.CreateDataEntry();
                    entries.Add(entry);
                }
            }

            var data = new ConfigurationsData()
            {
                foundryFolder = inputPath.Text,
                currentSelectedConfiguration = _modsConfigurations[_currentSelectedConfiguration].name,
                configurations = entries.ToArray()
            };
            var json = JsonConvert.SerializeObject(data);
            File.WriteAllText(_configFilePath, json);
        }

        private bool ToggleMod(string modName, bool state)
        {
            Debug.Assert(_repositories != null);

            for (int modIndex = 0; modIndex < _repositories.Length; modIndex++)
            {
                RepositoryData.Entry? repository = _repositories[modIndex];
                if (repository != null && repository.name == modName)
                {
                    return ToggleMod(modIndex, state);
                }
            }

            return false;
        }

        private bool ToggleMod(int modIndex, bool state)
        {
            Debug.Assert(_modsConfigurations != null);
            Debug.Assert(_repositories != null);
            Debug.Assert(_repositories.Length > modIndex);

            var repository = _repositories[modIndex];
            Debug.Assert(repository != null);

            string? modName = repository.name;
            if (modName != null)
            {
                var isEnabled = _modsConfigurations[_currentSelectedConfiguration].ToggleMod(modName, state);

                _ignoreEvents = true;
                listMods.SetItemChecked(modIndex, isEnabled);
                _ignoreEvents = false;

                if (repository.requirements != null)
                {
                    if (isEnabled)
                    {
                        foreach (var requirement in repository.requirements)
                        {
                            ToggleMod(requirement, true);
                        }
                    }
                    else
                    {
                        foreach (var otherRepository in _repositories)
                        {
                            if (otherRepository.name != null && (otherRepository.requirements?.Contains(modName) ?? false))
                            {
                                ToggleMod(otherRepository.name, false);
                            }
                        }
                    }
                }

                SaveConfigurations();

                return isEnabled;
            }

            return false;
        }

        private bool IsModEnabled(int modIndex)
        {
            Debug.Assert(_modsConfigurations != null);
            Debug.Assert(_repositories != null);
            Debug.Assert(_repositories.Length > modIndex);

            var repository = _repositories[modIndex];
            Debug.Assert(repository != null);

            string? modName = repository.name;
            if (modName != null)
            {
                return _modsConfigurations[_currentSelectedConfiguration].IsModEnabled(modName);
            }

            return false;
        }

        private async Task DownloadFile(HttpClient httpClient, string fileUrl, string pathToSave)
        {
            var httpResult = await httpClient.GetAsync(fileUrl);
            using var resultStream = await httpResult.Content.ReadAsStreamAsync();
            using var fileStream = File.Create(pathToSave);
            resultStream.CopyTo(fileStream);
        }

        [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode)]
        public static extern uint AssocQueryString(
            AssocF flags,
            AssocStr str,
            string pszAssoc,
            string? pszExtra,
            [Out] StringBuilder? pszOut,
            ref uint pcchOut
        );

        [Flags]
        public enum AssocF
        {
            None = 0,
            Init_NoRemapCLSID = 0x1,
            Init_ByExeName = 0x2,
            Open_ByExeName = 0x2,
            Init_DefaultToStar = 0x4,
            Init_DefaultToFolder = 0x8,
            NoUserSettings = 0x10,
            NoTruncate = 0x20,
            Verify = 0x40,
            RemapRunDll = 0x80,
            NoFixUps = 0x100,
            IgnoreBaseClass = 0x200,
            Init_IgnoreUnknown = 0x400,
            Init_Fixed_ProgId = 0x800,
            Is_Protocol = 0x1000,
            Init_For_File = 0x2000
        }

        public enum AssocStr
        {
            Command = 1,
            Executable,
            FriendlyDocName,
            FriendlyAppName,
            NoOpen,
            ShellNewValue,
            DDECommand,
            DDEIfExec,
            DDEApplication,
            DDETopic,
            InfoTip,
            QuickTip,
            TileInfo,
            ContentType,
            DefaultIcon,
            ShellExtension,
            DropTarget,
            DelegateExecute,
            Supported_Uri_Protocols,
            ProgID,
            AppID,
            AppPublisher,
            AppIconReference,
            Max
        }

        private bool TryGetTextEditorExecutable(out string textEditorPath)
        {
            const int S_OK = 0;
            const int S_FALSE = 1;

            uint length = 0;
            uint ret = AssocQueryString(AssocF.None, AssocStr.Executable, ".txt", null, null, ref length);
            if (ret != S_FALSE)
            {
                textEditorPath = string.Empty;
                return false;
            }

            var sb = new StringBuilder((int)length);
            ret = AssocQueryString(AssocF.None, AssocStr.Executable, ".txt", null, sb, ref length);
            if (ret != S_OK)
            {
                textEditorPath = string.Empty;
                return false;
            }

            textEditorPath = sb.ToString();
            return true;
        }

        private void listMods_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_ignoreEvents) return;
            e.NewValue = ToggleMod(e.Index, e.NewValue == CheckState.Checked) ? CheckState.Checked : CheckState.Unchecked;
        }

        private void listConfigurations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents) return;
            SelectConfiguration(listConfigurations.SelectedIndex);
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            openFileDialogFoundryExe.ShowDialog();
        }

        private void openFileDialogFoundryExe_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            inputPath.Text = Path.GetDirectoryName(openFileDialogFoundryExe.FileName);
            SaveConfigurations();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            InstallCurrentConfiguration();
        }

        private void buttonApplyAndRun_Click(object sender, EventArgs e)
        {
            InstallCurrentConfiguration();

            var exePath = Path.Combine(inputPath.Text, "Foundry.exe");
            if (!File.Exists(exePath))
            {
                MessageBox.Show(this, "Foundry.exe not found!");
                return;
            }

            Process.Start(new ProcessStartInfo()
            {
                FileName = exePath,
                WorkingDirectory = inputPath.Text
            });
        }

        private void buttonApplyAndRunSteamDemo_Click(object sender, EventArgs e)
        {
            InstallCurrentConfiguration();

            Process.Start(new ProcessStartInfo()
            {
                FileName = "steam://run/983870",
                UseShellExecute = true
            });
        }

        private void buttonAddConfiguration_Click(object sender, EventArgs e)
        {
            Debug.Assert(_modsConfigurations != null);

            var form = new FormTextInput();
            if (form.ShowDialog(this) == DialogResult.OK && !string.IsNullOrEmpty(form.textName.Text))
            {
                foreach (var configuration in _modsConfigurations)
                {
                    if (configuration.name == form.textName.Text)
                    {
                        MessageBox.Show(this, $"Configuration named '{form.textName.Text}' already exists.");
                        return;
                    }
                }

                _modsConfigurations.Add(new ModsConfiguration(form.textName.Text, false, new string[0]));
                FillConfigurationsList();
                SelectConfiguration(form.textName.Text);
                SaveConfigurations();
            }
        }

        private void buttonRemoveConfiguration_Click(object sender, EventArgs e)
        {
            if (_currentSelectedConfiguration <= 0) return;

            Debug.Assert(_modsConfigurations != null);
            Debug.Assert(_modsConfigurations.Count > _currentSelectedConfiguration);

            var currentConfiguration = _modsConfigurations[_currentSelectedConfiguration];
            Debug.Assert(currentConfiguration != null);

            var currentConfigurationName = currentConfiguration.name;
            Debug.Assert(currentConfigurationName != null);

            if (MessageBox.Show(this, "Delete Configuration", $"Are you sure you want to delete configuration '{currentConfigurationName}'?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _modsConfigurations.RemoveAt(_currentSelectedConfiguration);
                _currentSelectedConfiguration = -1;
                FillConfigurationsList();
                SelectConfiguration(0);
                SaveConfigurations();
            }
        }

        private void buttonModHome_Click(object sender, EventArgs e)
        {
            var modIndex = listMods.SelectedIndex;
            if (modIndex < 0) return;

            Debug.Assert(_repositories != null);
            Debug.Assert(_repositories.Length > modIndex);

            var repository = _repositories[modIndex];
            Debug.Assert(repository != null);

            string? modHome = repository.home;
            if (!string.IsNullOrEmpty(modHome))
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = modHome,
                    UseShellExecute = true
                });
            }
        }

        private void buttonModConfig_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_textEditorPath))
            {
                MessageBox.Show(this, "Text editor not found!");
                return;
            }

            var modIndex = listMods.SelectedIndex;
            if (modIndex < 0) return;

            Debug.Assert(_repositories != null);
            Debug.Assert(_repositories.Length > modIndex);

            var repository = _repositories[modIndex];
            Debug.Assert(repository != null);

            if (repository.config == null)
            {
                MessageBox.Show(this, "Selected mod has no config.");
                return;
            }

            var configPath = Path.Combine(inputPath.Text, "Config", repository.config);
            if (!File.Exists(configPath))
            {
                MessageBox.Show(this, "Config file not found!");
                return;
            }

            Process.Start(_textEditorPath, configPath);
        }
    }
}
