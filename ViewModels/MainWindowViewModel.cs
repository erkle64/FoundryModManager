using System.Collections.ObjectModel;
using System.IO;

namespace FoundryModManager2024
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool _checkForUpdates = true;
        public bool CheckForUpdates
        {
            get => _checkForUpdates;
            set { _checkForUpdates = value; OnPropertyChanged(); }
        }

        private string _foundryPath = string.Empty;
        public string FoundryPath
        {
            get => _foundryPath;
            set { _foundryPath = value; OnPropertyChanged(); MainWindow.SaveConfiguration(); LoadTweaks(); }
        }

        private ObservableCollection<ModsConfigurationViewModel> _configurations = new();
        public ObservableCollection<ModsConfigurationViewModel> Configurations
        {
            get => _configurations;
            set { _configurations = value; OnPropertyChanged(); }
        }

        private ModsConfigurationViewModel? _currentConfiguration = null;
        public ModsConfigurationViewModel? CurrentConfiguration
        {
            get => _currentConfiguration;
            set { _currentConfiguration = value; OnPropertyChanged(); MainWindow.SaveConfiguration(); }
        }

        private ThemeViewModel? _currentTheme = null;
        public ThemeViewModel? CurrentTheme
        {
            get => _currentTheme;
            set {
                _currentTheme = value;
                OnPropertyChanged();
                if (_currentTheme != null) App.SetTheme(_currentTheme.URL);
                MainWindow.SaveConfiguration();
            }
        }

        private ObservableCollection<ThemeViewModel> _themes = new();
        public ObservableCollection<ThemeViewModel> Themes
        {
            get => _themes;
            set { _themes = value; OnPropertyChanged(); }
        }

        private ObservableCollection<TweakViewModel> _tweaks = new();
        public ObservableCollection<TweakViewModel> Tweaks
        {
            get => _tweaks;
            set { _tweaks = value; OnPropertyChanged(); }
        }

        private TweakViewModel? _currentTweak = null;
        public TweakViewModel? CurrentTweak
        {
            get => _currentTweak;
            set { _currentTweak = value; OnPropertyChanged(); }
        }

        public void LoadTweaks()
        {
            Tweaks.Clear();
            CurrentTweak = null;

            var tweaksFilePath = Path.Combine(FoundryPath, "Tweaks");
            if (!Directory.Exists(tweaksFilePath)) return;

            foreach (var filePath in Directory.GetFiles(tweaksFilePath, "*.*", SearchOption.AllDirectories))
            {
                if (filePath.Contains(".zip") || filePath.Contains(".json"))
                {
                    var tweak = new TweakViewModel(tweaksFilePath, Path.GetRelativePath(tweaksFilePath, filePath));
                    Tweaks.Add(tweak);
                }
            }
        }
    }
}
