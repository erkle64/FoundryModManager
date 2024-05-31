using System.IO;

namespace FoundryModManager2024
{
    public class TweakViewModel : ViewModelBase
    {
        public TweakViewModel(string rootPath, string path)
        {
            _rootPath = rootPath;

            _name = path;
            while(_name.Contains('.')) _name = Path.GetFileNameWithoutExtension(_name);

            _filePath = path;

            _directoryPath = Path.GetDirectoryName(path) ?? "";

            var extension = Path.GetExtension(path).ToLower();
            _isEnabled = extension == ".json" || extension == ".zip";

            _isZip = path.Contains(".zip");
        }

        private string _rootPath;

        public string DisplayName
        {
            get => Path.Combine(_directoryPath, $"{_name}{(_isZip ? ".zip" : ".json")}");
        }

        private string _name;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        private string _directoryPath;
        public string DirectoryPath
        {
            get => _directoryPath;
            set { _directoryPath = value; OnPropertyChanged(); }
        }

        private string _filePath;
        public string FilePath
        {
            get => _filePath;
            set { _filePath = value; OnPropertyChanged(); }
        }

        private bool _isZip = false;
        public bool IsZip
        {
            get => _isZip;
            set { _isZip = value; OnPropertyChanged(); }
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get => _isEnabled;
            set {
                try
                {
                    var newPath = Path.Combine(DirectoryPath, Name + (IsZip ? ".zip" : ".json") + (value ? "" : ".disabled"));
                    File.Move(Path.Combine(_rootPath, FilePath), Path.Combine(_rootPath, newPath));
                    _isEnabled = value;
                    FilePath = newPath;
                    OnPropertyChanged();
                }
                catch { }
            }
        }
    }
}
