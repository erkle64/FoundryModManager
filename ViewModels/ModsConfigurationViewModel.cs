using System.Collections.ObjectModel;

namespace FoundryModManager2024
{
    public class ModsConfigurationViewModel : ViewModelBase
    {
        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        private bool _isVanilla = false;
        public bool IsVanilla
        {
            get => _isVanilla;
            set { _isVanilla = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ModConfigurationViewModel> _mods = new();
        public ObservableCollection<ModConfigurationViewModel> Mods
        {
            get => _mods;
            set { _mods = value; OnPropertyChanged(); }
        }

        private ModConfigurationViewModel? _selectedMod = null;
        public ModConfigurationViewModel? SelectedMod
        {
            get => _selectedMod;
            set { _selectedMod = value; OnPropertyChanged(); }
        }

        public void UpdateDependencies(ModConfigurationViewModel modConfiguration, bool isEnabled)
        {
            if (isEnabled)
            {
                foreach (var requirement in modConfiguration.Mod!.Requirements)
                {
                    foreach (var mod in Mods.Where(m => m.Mod!.Name == requirement))
                    {
                        mod.IsEnabled = true;
                    }
                }
            }
            else
            {
                foreach (var mod in Mods)
                {
                    if (mod.Mod!.Requirements.Any(r => r == modConfiguration.Mod!.Name))
                    {
                        mod.IsEnabled = false;
                    }
                }
            }
        }
    }
}
