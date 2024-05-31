namespace FoundryModManager2024
{
    public class ThemeViewModel : ViewModelBase
    {
        public ThemeViewModel(string name, string url)
        {
            _name = name;
            _url = url;
        }

        private string _name;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        private string _url;
        public string URL
        {
            get => _url;
            set { _url = value; OnPropertyChanged(); }
        }
    }
}
