using Narod.SteamGameFinder;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows;

namespace FoundryModManager2024
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ApplicationInitialize = _applicationInitialize;
        }

        public static new App? Current
        {
            get { return Application.Current as App; }
        }

        public ResourceDictionary ThemeDictionary
        {
            get { return Resources.MergedDictionaries[0]; }
            set { Resources.MergedDictionaries[0] = value; }
        }

        public static void SetTheme(string url)
        {
            Current!.ThemeDictionary = new ResourceDictionary { Source = new Uri(url, UriKind.Relative) };
        }

        internal delegate Action ApplicationInitializeDelegate(SplashScreenWindow splashWindow);
        internal ApplicationInitializeDelegate ApplicationInitialize;
        private Action _applicationInitialize(SplashScreenWindow splashWindow)
        {
            var viewModel = new MainWindowViewModel();
            viewModel.Themes.Clear();
            viewModel.Themes.Add(new ThemeViewModel("Dark", "/Resources/Themes/DarkMode.xaml"));
            viewModel.Themes.Add(new ThemeViewModel("Light", "/Resources/Themes/LightMode.xaml"));
            viewModel.CurrentTheme = viewModel.Themes.FirstOrDefault();

            var appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            var dataFolderPath = Path.Combine(appdataPath, @"Erkle\FoundryModManager2024");
            if (!Directory.Exists(dataFolderPath)) Directory.CreateDirectory(dataFolderPath);

            var cacheFolderPath = Path.Combine(dataFolderPath, @"Cache");
            if (!Directory.Exists(cacheFolderPath)) Directory.CreateDirectory(cacheFolderPath);

            var configFilePath = Path.Combine(dataFolderPath, @"configurations.json");

            var modEntries = LoadAllRepositories(cacheFolderPath, dataFolderPath);
            var mods = modEntries.Select(x => new ModViewModel
            {
                Name = x.name ?? x.folder ?? "unnamed",
                Description = $"{(x.author != null ? $"Author: {x.author}\r\n" : "")}{x.description ?? string.Empty}",
                Requirements = x.requirements ?? new string[0],
                Home = x.home ?? string.Empty,
                Config = x.config ?? string.Empty,
                Folder = x.folder ?? x.name ?? string.Empty,
                URL = x.url ?? string.Empty,
                Versions = x.versions ?? new Dictionary<string, string>()
            }).ToArray();
            Array.Sort(mods, (x, y) => string.Compare(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase));
            LoadConfig(configFilePath, viewModel, mods, out var windowConfig);

            return () =>
            {
                MainWindow = new MainWindow(viewModel, dataFolderPath, cacheFolderPath, configFilePath, mods, windowConfig);
                MainWindow.Show();
            };
        }

        private RepositoryData.Entry[] LoadAllRepositories(string cacheFolderPath, string dataFolderPath)
        {
            Debug.Assert(cacheFolderPath != null);
            Debug.Assert(dataFolderPath != null);

            var mods = new RepositoryData.Entry[0];
            var localPath = Path.Combine(dataFolderPath, "sources.2024.json");
            if (File.Exists(localPath))
            {
                var json = File.ReadAllText(localPath);
                mods = LoadAllRepositoriesFromJSON(json, cacheFolderPath, dataFolderPath);
            }
            else
            {
                using (var webClient = new WebClient())
                {
                    try
                    {
                        var json = webClient.DownloadString("https://erkle64.github.io/FoundryModManager/sources.2024.json");
                        mods = LoadAllRepositoriesFromJSON(json, cacheFolderPath, dataFolderPath);
                    }
                    catch (WebException ex)
                    {
                        MessageBox.Show($"Failed to download repository sources.\n{ex.Message}");
                    }
                }
            }

            if (mods.Length == 0)
            {
                throw new Exception("Repository data not found.");
            }

            return mods;
        }

        private RepositoryData.Entry[] LoadAllRepositoriesFromJSON(string json, string cacheFolderPath, string dataFolderPath)
        {
            var data = JsonConvert.DeserializeObject<SourcesData>(json);
            if (data != null && data.sources != null)
            {
                var sources = data.sources;

                var combinedRepositories = new List<RepositoryData.Entry>();
                foreach (var source in sources)
                {
                    var sourceRepositories = LoadRepositoriesFrom(source, cacheFolderPath, dataFolderPath);
                    if (sourceRepositories != null)
                    {
                        combinedRepositories.AddRange(sourceRepositories);
                    }
                }
                var repositories = combinedRepositories.ToArray();

                var mods = new List<RepositoryData.Entry>();
                foreach (var repository in repositories)
                {
                    if (repository.name != null)
                    {
                        mods.Add(repository);

                        var cachePath = Path.Combine(cacheFolderPath!, repository.name);
                        if (!Directory.Exists(cachePath)) Directory.CreateDirectory(cachePath);
                    }
                }
                
                return mods.ToArray();
            }

            return new RepositoryData.Entry[0];
        }

        private RepositoryData.Entry[]? LoadRepositoriesFrom(string modDataURL, string cacheFolderPath, string dataFolderPath)
        {
            Debug.Assert(cacheFolderPath != null);
            Debug.Assert(dataFolderPath != null);

            var localPath = Path.Combine(dataFolderPath, Path.GetFileName(new Uri(modDataURL).AbsolutePath));
            if (File.Exists(localPath))
            {
                var json = File.ReadAllText(localPath);
                return LoadRepositoriesFromJSON(json);
            }
            else
            {
                using (var webClient = new WebClient())
                {
                    try
                    {
                        var json = webClient.DownloadString(modDataURL);
                        return LoadRepositoriesFromJSON(json);
                    }
                    catch (WebException ex)
                    {
                        MessageBox.Show($"Failed to download repository sources.\n{ex.Message}");
                    }
                }
            }

            return null;
        }

        private static RepositoryData.Entry[] LoadRepositoriesFromJSON(string json)
        {
            var data = JsonConvert.DeserializeObject<RepositoryData>(json);
            if (data != null && data.repositories != null)
            {
                return data.repositories;
            }
            else
            {
                throw new Exception("Invalid repository data.");
            }
        }

        private void LoadConfig(string configFilePath, MainWindowViewModel viewModel, ModViewModel[] mods, out MainWindow.WindowConfig windowConfig)
        {
            var vanilla = new ModsConfigurationViewModel
            {
                Name = "Vanilla",
                IsVanilla = true
            };
            viewModel.Configurations.Add(vanilla);

            foreach (var mod in mods)
            {
                vanilla.Mods.Add(new ModConfigurationViewModel(vanilla)
                {
                    Mod = mod,
                    IsEnabled = false
                });
            }

            windowConfig = new MainWindow.WindowConfig();

            if (File.Exists(configFilePath))
            {
                var json = File.ReadAllText(configFilePath);
                var data = JsonConvert.DeserializeObject<ConfigurationsData>(json);
                if (data != null)
                {
                    if (!string.IsNullOrEmpty(data.foundryFolder))
                    {
                        viewModel.FoundryPath = data.foundryFolder;
                    }
                    else
                    {
                        var steamGameLocator = new SteamGameLocator();
                        if (steamGameLocator.getIsSteamInstalled())
                        {
                            var gameInfo = steamGameLocator.getGameInfoByFolder("FOUNDRY");
                            if (!string.IsNullOrEmpty(gameInfo.steamGameLocation))
                            {
                                viewModel.FoundryPath = gameInfo.steamGameLocation.Replace(@"\\", @"\");
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(data.theme))
                    {
                        viewModel.CurrentTheme = viewModel.Themes.FirstOrDefault(x => x.Name == data.theme);
                    }

                    if (data.configurations != null)
                    {
                        foreach (var configuration in data.configurations)
                        {
                            var modsConfiguration = new ModsConfigurationViewModel
                            {
                                Name = configuration.name ?? "unnamed",
                                IsVanilla = false
                            };
                            viewModel.Configurations.Add(modsConfiguration);

                            foreach (var mod in mods)
                            {
                                modsConfiguration.Mods.Add(new ModConfigurationViewModel(modsConfiguration)
                                {
                                    Mod = mod,
                                    IsEnabled = configuration.enabledMods?.Any(x => x == mod.Name) ?? false
                                });
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(data.currentSelectedConfiguration))
                    {
                        viewModel.CurrentConfiguration = viewModel.Configurations.Where(x => x.Name == data.currentSelectedConfiguration).FirstOrDefault();
                    }
                    else
                    {
                        viewModel.CurrentConfiguration = viewModel.Configurations.FirstOrDefault();
                    }

                    windowConfig.Width = data.windowWidth;
                    windowConfig.Height = data.windowHeight;
                    windowConfig.Maximized = data.windowMaximized;
                }
            }

            if (viewModel.Configurations.Count < 2)
            {
                var modsConfiguration = new ModsConfigurationViewModel
                {
                    Name = "Default",
                    IsVanilla = false
                };
                viewModel.Configurations.Add(modsConfiguration);

                foreach (var mod in mods)
                {
                    modsConfiguration.Mods.Add(new ModConfigurationViewModel(modsConfiguration)
                    {
                        Mod = mod,
                        IsEnabled = false
                    });
                }
            }
        }
    }
}
