
namespace FoundryModManager2024
{
    public class ConfigurationsData
    {
        public class Entry
        {
            public string? name;
            public string[]? enabledMods;
        }

        public string? foundryFolder;
        public string? theme;
        public string? currentSelectedConfiguration;
        public Entry[]? configurations;
        public double? windowWidth;
        public double? windowHeight;
        public bool? windowMaximized;
        public bool? checkForUpdates;
    }
}