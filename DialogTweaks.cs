namespace FoundryModManager
{
    public partial class DialogTweaks : Form
    {
        private List<string> _filePaths = new();

        public DialogTweaks(string tweaksPath)
        {
            InitializeComponent();

            //folder is not always present - initial startup
            if(!Directory.Exists(tweaksPath)) { Directory.CreateDirectory(tweaksPath); }

            _filePaths.Clear();
            checkedListBoxTweaks.Items.Clear();
            foreach (var filePath in Directory.EnumerateFiles(tweaksPath, "*.json*", SearchOption.TopDirectoryOnly))
            {
                checkedListBoxTweaks.Items.Add(Path.GetFileNameWithoutExtension(filePath), IsTweakEnabled(filePath));
                _filePaths.Add(filePath);
            }
        }

        private static bool IsTweakEnabled(string filePath)
        {
            return Path.GetExtension(filePath).ToLower() == ".json";
        }

        public void ApplyChanges()
        {
            var index = 0;
            foreach (var filePath in _filePaths)
            {
                if (File.Exists(filePath))
                {
                    var wasChecked = IsTweakEnabled(filePath);
                    var isChecked = checkedListBoxTweaks.GetItemChecked(index);
                    if (wasChecked != isChecked)
                    {
                        File.Move(filePath, Path.Combine(Path.GetDirectoryName(filePath)!, Path.GetFileNameWithoutExtension(filePath) + (isChecked ? ".json" : ".json.disabled")));
                    }
                }
                index++;
            }
        }
    }
}
