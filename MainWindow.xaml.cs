using Narod.SteamGameFinder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace FoundryModManager2024
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;

        private readonly string _dataFolderPath;
        private readonly string _cacheFolderPath;
        private readonly string _configFilePath;

        private static MainWindow? _instance = null;
        private static int _disableConfigUpdate = 0;
        private ModViewModel[] _mods;

        private bool _hasDoneVersionCheck = false;

        public struct WindowConfig
        {
            public double? Width;
            public double? Height;
            public bool? Maximized;
        }

        public enum InstallerType
        {
            MSI,
            NET6,
            Standalone
        }

        public MainWindow(MainWindowViewModel viewModel, string dataFolderPath, string cacheFolderPath, string configFilePath, ModViewModel[] mods, WindowConfig windowConfig)
        {
            _instance = this;
            _viewModel = viewModel;
            _dataFolderPath = dataFolderPath;
            _cacheFolderPath = cacheFolderPath;
            _configFilePath = configFilePath;
            _mods = mods;

            if (_viewModel.CurrentConfiguration == null)
            {
                _viewModel.CurrentConfiguration = viewModel.Configurations.LastOrDefault();
            }

            InitializeComponent();
            StateChanged += MainWindowStateChangeRaised;
            DataContext = _viewModel;

            if (windowConfig.Width != null)
            {
                Width = windowConfig.Width.Value;
            }
            if (windowConfig.Height != null)
            {
                Height = windowConfig.Height.Value;
            }
            if (windowConfig.Maximized != null)
            {
                if (windowConfig.Maximized.Value)
                {
                    WindowState = WindowState.Maximized;
                    MainWindowBorder.BorderThickness = new Thickness(8);
                    RestoreButton.Visibility = Visibility.Visible;
                    MaximizeButton.Visibility = Visibility.Collapsed;
                }
            }

            UpdateModUpdateVisibilities();
        }

        public static void DisableConfigUpdate() => _disableConfigUpdate++;
        public static void EnableConfigUpdate() => _disableConfigUpdate--;

        public static void SaveConfiguration()
        {
            if (_instance == null || _disableConfigUpdate > 0) return;

            var data = new ConfigurationsData();
            data.foundryFolder = _instance._viewModel.FoundryPath;

            data.theme = _instance._viewModel.CurrentTheme?.Name ?? "Dark";

            data.currentSelectedConfiguration = _instance._viewModel.CurrentConfiguration?.Name ?? string.Empty;

            var configurations = new List<ConfigurationsData.Entry>();
            foreach (var item in _instance._viewModel.Configurations)
            {
                if (item.IsVanilla) continue;

                configurations.Add(new ConfigurationsData.Entry
                {
                    name = item.Name,
                    enabledMods = item.Mods.Where(m => m.IsEnabled).Select(m => m.Mod!.Name).ToArray(),
                });
            }
            data.configurations = configurations.ToArray();

            data.windowWidth = _instance!.Width;
            data.windowHeight = _instance!.Height;
            data.windowMaximized = _instance!.WindowState == WindowState.Maximized;

            data.checkForUpdates = _instance._viewModel.CheckForUpdates;

            data.closeOnRun = _instance._viewModel.CloseOnRun;

            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(_instance._configFilePath, json);
        }

        private bool CheckForUpdate(out string currentVersion, out string newVersion, out InstallerType installerType)
        {
            try
            {
                var exePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule!.FileName) ?? string.Empty;
                var versionPath = Path.Combine(exePath, "version.txt");
                if (!File.Exists(versionPath))
                {
                    currentVersion = string.Empty;
                    newVersion = string.Empty;
                    installerType = InstallerType.MSI;
                    return false;
                }
                var currentVersionText = File.ReadAllText(versionPath);

                using var webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "erkle64/FoundryModManager");
                var jsonString = webClient.DownloadString("https://api.github.com/repos/erkle64/FoundryModManager/releases/latest");
                var json = JObject.Parse(jsonString);
                if (!json.TryGetValue("tag_name", out var latestVersionValue))
                {
                    currentVersion = string.Empty;
                    newVersion = string.Empty;
                    installerType = InstallerType.MSI;
                    return false;
                }

                var installerTypePath = Path.Combine(exePath, "installer_type.txt");
                if (File.Exists(installerTypePath))
                {
                    switch (File.ReadAllText(installerTypePath).ToLower())
                    {
                        case "net6":
                            installerType = InstallerType.NET6;
                            break;

                        case "standalone":
                            installerType = InstallerType.Standalone;
                            break;

                        default:
                            installerType = InstallerType.MSI;
                            break;
                    }
                }
                else
                {
                    installerType = InstallerType.MSI;
                }

                var latestVersionText = latestVersionValue.ToString();
                currentVersion = currentVersionText;
                newVersion = latestVersionText;
                return latestVersionText != currentVersionText;
            }
            catch
            {
                currentVersion = string.Empty;
                newVersion = string.Empty;
                installerType = InstallerType.MSI;
                return false;
            }
        }

        private string GetTemporaryDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            if (File.Exists(tempDirectory))
            {
                return GetTemporaryDirectory();
            }
            else
            {
                Directory.CreateDirectory(tempDirectory);
                return tempDirectory;
            }
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

        // Can execute
        private void CommandBinding_CanExecute(object? sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        // Minimize
        private void CommandBinding_Executed_Minimize(object? sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        // Maximize
        private void CommandBinding_Executed_Maximize(object? sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }

        // Restore
        private void CommandBinding_Executed_Restore(object? sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.RestoreWindow(this);
        }

        // Close
        private void CommandBinding_Executed_Close(object? sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        // State change
        private void MainWindowStateChangeRaised(object? sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                MainWindowBorder.BorderThickness = new Thickness(8);
                RestoreButton.Visibility = Visibility.Visible;
                MaximizeButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                MainWindowBorder.BorderThickness = new Thickness(0);
                RestoreButton.Visibility = Visibility.Collapsed;
                MaximizeButton.Visibility = Visibility.Visible;
            }
        }

        private void InstallCurrentConfiguration(IProgress<string> progress)
        {
            Debug.Assert(_cacheFolderPath != null);

            var exePath = Path.Combine(_viewModel.FoundryPath, "FOUNDRY.exe");
            if (!File.Exists(exePath))
            {
                MessageBox.Show(this, "FOUNDRY.exe not found!");
                return;
            }

            var modsPath = Path.Combine(_viewModel.FoundryPath, "Mods");
            if (!Directory.Exists(modsPath)) Directory.CreateDirectory(modsPath);

            var versionPath = Path.Combine(_viewModel.FoundryPath, "version.txt");
            var version = "0.0.0.0";
            if (File.Exists(versionPath))
            {
                version = File.ReadAllText(versionPath);
            }

            using var webClient = new WebClient();

            Debug.Assert(_viewModel.CurrentConfiguration?.Mods != null);
            foreach (var mod in _viewModel.CurrentConfiguration.Mods)
            {
                if (mod.IsEnabled)
                {
                    InstallMod(mod.Mod!, modsPath, webClient, new Version(version), progress);
                }
                else
                {
                    UninstallMod(mod.Mod!, modsPath, progress);
                }
            }

            progress.Report("Done!");
            Thread.Sleep(1000);
        }

        private void UninstallMod(ModViewModel mod, string modsPath, IProgress<string> progress)
        {
            progress.Report($"Uninstalling {mod.Name}...");

            var folderName = mod.Folder ?? mod.Name;
            Debug.Assert(folderName != null);

            var modPath = Path.Combine(modsPath, folderName);
            if (Directory.Exists(modPath)) Directory.Delete(modPath, true);
        }

        private void InstallMod(ModViewModel mod, string modsPath, WebClient webClient, Version version, IProgress<string> progress)
        {
            Debug.Assert(_cacheFolderPath != null);

            progress.Report($"Installing {mod.Name}...");

            var modURL = mod.URL;
            var baseModURL = mod.URL;
            GetModURLs(version, ref modURL, ref baseModURL, mod.Versions);

            Debug.Assert(modURL != null);

            var folderName = mod.Folder ?? mod.Name;
            Debug.Assert(folderName != null);

            var modPath = Path.Combine(modsPath, folderName);
            if (!Directory.Exists(modsPath)) Directory.CreateDirectory(modPath);

            var cachedModFolderPath = Path.Combine(_cacheFolderPath, mod.Name);
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
                progress.Report($"Downloading {Path.GetFileName(modURL)}...");
                try
                {
                    webClient.DownloadFile(modURL, cachedModPath);

                    File.WriteAllText(cachedModSourcePath, modURL);
                }
                catch (WebException ex)
                {
                    MessageBox.Show(this, $"Failed to download {Path.GetFileName(modURL)}\n{ex.Message}");
                }
            }

            if (File.Exists(cachedModPath))
            {
                progress.Report($"Extracting {Path.GetFileName(modURL)}...");
                ZipFile.ExtractToDirectory(cachedModPath, modPath, true);
            }
        }

        private static void GetModURLs(Version version, ref string modURL, ref string baseModURL, Dictionary<string, string>? modVersions)
        {
            if (modVersions != null)
            {
                foreach (var versionInfo in modVersions)
                {
                    var m = Regex.Match(versionInfo.Key, @"^(<=?|>=?|=)(\d+)\.(\d+)\.(\d+)\.(\d+)$", RegexOptions.Singleline);
                    if (m.Success)
                    {
                        try
                        {
                            var matchVersion = new Version(Convert.ToInt32(m.Groups[2].Value), Convert.ToInt32(m.Groups[3].Value), Convert.ToInt32(m.Groups[4].Value), Convert.ToInt32(m.Groups[5].Value));
                            switch (m.Groups[1].Value)
                            {
                                case ">=":
                                    if (version >= matchVersion) modURL = versionInfo.Value;
                                    break;

                                case ">":
                                    if (version > matchVersion) modURL = versionInfo.Value;
                                    break;

                                case "<=":
                                    if (version <= matchVersion) modURL = versionInfo.Value;
                                    break;

                                case "<":
                                    if (version < matchVersion) modURL = versionInfo.Value;
                                    break;

                                case "=":
                                    if (version == matchVersion) modURL = versionInfo.Value;
                                    break;
                            }
                            break;
                        }
                        catch (Exception) { }
                    }
                }
            }
        }

        internal static void UpdateModUpdateVisibilities()
        {
            if (_instance == null) return;

            var versionPath = Path.Combine(_instance._viewModel.FoundryPath, "version.txt");
            var versionText = "0.0.0.0";
            if (File.Exists(versionPath))
            {
                versionText = File.ReadAllText(versionPath);
            }
            var version = new Version(versionText);

            Debug.Assert(_instance._viewModel.CurrentConfiguration?.Mods != null);
            foreach (var modConfig in _instance._viewModel.CurrentConfiguration.Mods)
            {
                if (!modConfig.IsEnabled)
                {
                    modConfig.Mod!.UpdateVisibility = Visibility.Collapsed;
                    continue;
                }

                var mod = modConfig.Mod!;
                var updatePending = true;
                var modURL = mod.URL;
                var baseModURL = mod.URL;
                GetModURLs(version, ref modURL, ref baseModURL, mod.Versions);

                var cachedModFolderPath = Path.Combine(_instance._cacheFolderPath, mod.Name);
                if (Directory.Exists(cachedModFolderPath))
                {
                    var cachedModPath = Path.Combine(cachedModFolderPath, Path.GetFileName(modURL));
                    var cachedModSourcePath = Path.Combine(cachedModFolderPath, "source.url");

                    if (File.Exists(cachedModPath))
                    {
                        if (File.Exists(cachedModSourcePath))
                        {
                            var sourceURL = File.ReadAllText(cachedModSourcePath);
                            if (sourceURL == modURL) updatePending = false;
                        }
                    }
                }

                mod.UpdateVisibility = updatePending ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void BrowseFoundryPathButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Foundry Executable|FOUNDRY.exe";
            dialog.FileName = _viewModel.FoundryPath;
            if (dialog.ShowDialog() == true)
            {
                _viewModel.FoundryPath = Path.GetDirectoryName(dialog.FileName) ?? string.Empty;
            }
        }

        private void AutoFoundryPathButton_Click(object sender, RoutedEventArgs e)
        {
            var steamGameLocator = new SteamGameLocator();
            if (steamGameLocator.getIsSteamInstalled())
            {
                try
                {
                    var gameInfo = steamGameLocator.getGameInfoByFolder("FOUNDRY");
                    if (!string.IsNullOrEmpty(gameInfo.steamGameLocation))
                    {
                        _viewModel.FoundryPath = gameInfo.steamGameLocation.Replace(@"\\", @"\");
                    }
                }
                catch
                {
                    _viewModel.FoundryPath = string.Empty;
                    MessageBox.Show("Failed to find FOUNDRY Steam installation.");
                }
            }
        }

        private void OpenFoundryPathButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(_viewModel.FoundryPath))
            {
                MessageBox.Show("FOUNDRY folder not found.");
                return;
            }

            Process.Start(new ProcessStartInfo()
            {
                FileName = "explorer.exe",
                Arguments = $"\"{_viewModel.FoundryPath}\""
            });
        }

        private void ModHomepageButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.CurrentConfiguration == null) return;
            if (_viewModel.CurrentConfiguration.SelectedMod == null) return;
            if (string.IsNullOrEmpty(_viewModel.CurrentConfiguration.SelectedMod.Mod!.Home)) return;

            Process.Start(new ProcessStartInfo()
            {
                FileName = _viewModel.CurrentConfiguration.SelectedMod.Mod!.Home,
                UseShellExecute = true
            });
        }

        private void ModConfigFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.CurrentConfiguration == null) return;
            if (_viewModel.CurrentConfiguration.SelectedMod == null) return;

            if (string.IsNullOrEmpty(_viewModel.CurrentConfiguration.SelectedMod.Mod!.Config))
            {
                MessageBox.Show("Config file not found.");
                return;
            }

            if (!TryGetTextEditorExecutable(out var textEditorPath))
            {
                MessageBox.Show("Text editor not found.");
                return;
            }

            var configPath = Path.Combine(_viewModel.FoundryPath, "Config", _viewModel.CurrentConfiguration.SelectedMod.Mod!.Config);
            if (!File.Exists(configPath))
            {
                MessageBox.Show("Config file not found.");
                return;
            }

            Process.Start(new ProcessStartInfo()
            {
                FileName = textEditorPath,
                Arguments = $"\"{configPath}\""
            });
        }

        private void ModFolderButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.CurrentConfiguration == null) return;
            if (_viewModel.CurrentConfiguration.SelectedMod == null) return;

            var modPath = Path.Combine(_viewModel.FoundryPath, "Mods", _viewModel.CurrentConfiguration.SelectedMod.Mod!.Folder);
            if (!Directory.Exists(modPath))
            {
                MessageBox.Show("Mod folder not found.");
                return;
            }

            Process.Start(new ProcessStartInfo()
            {
                FileName = "explorer.exe",
                Arguments = $"\"{modPath}\""
            });
        }

        private void ModsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (_viewModel.CurrentConfiguration == null) return;
            if (_viewModel.CurrentConfiguration.SelectedMod == null) return;
            _viewModel.CurrentConfiguration.SelectedMod.IsEnabled = !_viewModel.CurrentConfiguration.SelectedMod.IsEnabled;
        }

        private void TweaksListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (_viewModel.CurrentTweak == null) return;
            _viewModel.CurrentTweak.IsEnabled = !_viewModel.CurrentTweak.IsEnabled;
        }

        private void AddConfigurationButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddConfigurationDialog();
            if (dialog.ShowDialog() == true && !string.IsNullOrEmpty(dialog.ConfigurationName))
            {
                var modConfiguration = new ModsConfigurationViewModel()
                {
                    Name = dialog.ConfigurationName,
                    IsVanilla = false,
                    SelectedMod = null
                };
                modConfiguration.Mods = new ObservableCollection<ModConfigurationViewModel>(_mods.Select(m =>
                        new ModConfigurationViewModel(modConfiguration)
                        {
                            Mod = m,
                            IsEnabled = false
                        }
                    ));
                _viewModel.Configurations!.Add(modConfiguration);
                SaveConfiguration();
            }
        }

        private void RemoveConfigurationButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.CurrentConfiguration == null) return;

            if (MessageBox.Show($"Delete configuration '{_viewModel.CurrentConfiguration.Name}'", "Delete", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                _viewModel.Configurations!.Remove(_viewModel.CurrentConfiguration);
                _viewModel.CurrentConfiguration = null;
                SaveConfiguration();
            }
        }

        private void ApplyRunSteamButton_Click(object sender, RoutedEventArgs e)
        {
            var applyWindow = new ApplyWindow(progress =>
            {
                InstallCurrentConfiguration(progress);

                return () =>
                {
                    UpdateModUpdateVisibilities();

                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = "steam://run/983870",
                        UseShellExecute = true
                    });

                    if (_viewModel.CloseOnRun) Close();
                };
            });
            applyWindow.ShowDialog();
        }

        private void ApplyRunButton_Click(object sender, RoutedEventArgs e)
        {
            var applyWindow = new ApplyWindow(progress =>
            {
                InstallCurrentConfiguration(progress);

                return () =>
                {
                    UpdateModUpdateVisibilities();

                    var exePath = Path.Combine(_viewModel.FoundryPath, "Foundry.exe");
                    if (!File.Exists(exePath))
                    {
                        MessageBox.Show(this, "Foundry.exe not found!");
                        return;
                    }

                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = exePath,
                        WorkingDirectory = _viewModel.FoundryPath
                    });

                    if (_viewModel.CloseOnRun) Close();
                };
            });
            applyWindow.ShowDialog();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            var applyWindow = new ApplyWindow(progress =>
            {
                InstallCurrentConfiguration(progress);

                return () =>
                {
                    UpdateModUpdateVisibilities();
                };
            });
            applyWindow.ShowDialog();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            });
            e.Handled = true;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            if (_hasDoneVersionCheck) return;

            _hasDoneVersionCheck = true;

            if (_viewModel.CheckForUpdates) AskForUpdateIfFound(false);
        }

        private void AskForUpdateIfFound(bool notifyUpToDate)
        {
            if (CheckForUpdate(out var currentVersion, out var newVersion, out var installerType))
            {
                var downloadFilename = "FoundryModManagerSetup.msi";
                switch (installerType)
                {
                    case InstallerType.NET6:
                        downloadFilename = "FoundryModManager_net6.exe";
                        break;

                    case InstallerType.Standalone:
                        downloadFilename = "FoundryModManager_standalone.exe";
                        break;
                }

                if (MessageBox.Show($"Current version: {currentVersion}\r\nNew version: {newVersion}\r\nDownload {downloadFilename}?", "New Version Available", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    using var webClient = new WebClient();
                    try
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = $"https://github.com/erkle64/FoundryModManager/releases/latest/download/{downloadFilename}",
                            UseShellExecute = true
                        });
                        Close();
                        return;
                    }
                    catch
                    {
                        MessageBox.Show("Failed to download update.");
                    }
                }
            }
            else if (notifyUpToDate)
            {
                MessageBox.Show("FoundryModManager is up to date.");
            }
        }

        private void RefreshTweaksButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadTweaks();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveConfiguration();
        }

        private void CheckForUpdatesButton_Click(object sender, RoutedEventArgs e)
        {
            AskForUpdateIfFound(true);
        }

        private void ClearCacheFolderButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Clearing the cache will cause all enabled mods to be redownloaded next time you click Apply.\nAre you sure?", "Clear Cache", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var applyWindow = new ApplyWindow(progress =>
                {
                    if (Directory.Exists(_cacheFolderPath))
                    {
                        foreach (var dirPath in Directory.GetDirectories(_cacheFolderPath))
                        {
                            progress.Report($"Deleting {Path.GetFileName(dirPath)}...");
                            Directory.Delete(dirPath, true);
                        }
                    }

                    progress.Report("Done!");
                    Thread.Sleep(1000);

                    return () =>
                    {
                    };
                });
                applyWindow.ShowDialog();
            }
        }

        private void OpenCacheFolderButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(_cacheFolderPath))
            {
                MessageBox.Show("Cache folder not found.");
                return;
            }

            Process.Start(new ProcessStartInfo()
            {
                FileName = "explorer.exe",
                Arguments = _cacheFolderPath
            });
        }
    }
}