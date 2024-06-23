namespace FoundryModManager2024
{
    public class ModConfigurationViewModel : ViewModelBase
    {
        private ModsConfigurationViewModel _parent;

        public ModConfigurationViewModel(ModsConfigurationViewModel parent)
        {
            _parent = parent;
        }

        private ModViewModel? _mod = null;
        public ModViewModel? Mod
        {
            get => _mod;
            set { _mod = value; OnPropertyChanged(); }
        }

        private bool _isEnabled = false;
        public bool IsEnabled
        {
            get => _isEnabled;
            set {
                if (_parent.IsVanilla) return;
                MainWindow.DisableConfigUpdate();
                _isEnabled = value;
                OnPropertyChanged();
                _parent.UpdateDependencies(this, _isEnabled);
                MainWindow.EnableConfigUpdate();
                MainWindow.SaveConfiguration();
                MainWindow.UpdateModUpdateVisibilities();
            }
        }
    }
}
