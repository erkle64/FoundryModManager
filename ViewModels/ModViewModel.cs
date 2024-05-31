namespace FoundryModManager2024
{
    public class ModViewModel : ViewModelBase
    {
        private string _name = "unnamed";
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        private string _description = string.Empty;
        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(); }
        }

        private string[] _requirements = new string[0];
        public string[] Requirements
        {
            get => _requirements;
            set { _requirements = value; OnPropertyChanged(); }
        }

        private string _home = string.Empty;
        public string Home
        {
            get => _home;
            set { _home = value; OnPropertyChanged(); }
        }

        private string _config = string.Empty;
        public string Config
        {
            get => _config;
            set { _config = value; OnPropertyChanged(); }
        }

        private string _folder = string.Empty;
        public string Folder
        {
            get => _folder;
            set { _folder = value; OnPropertyChanged(); }
        }

        private string _url = string.Empty;
        public string URL
        {
            get => _url;
            set { _url = value; OnPropertyChanged(); }
        }

        private Dictionary<string, string> _versions = new Dictionary<string, string>();
        public Dictionary<string, string> Versions
        {
            get => _versions;
            set { _versions = value; OnPropertyChanged(); }
        }
    }
}
