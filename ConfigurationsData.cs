
namespace FoundryModManager
{
    public class ConfigurationsData
    {
        public class Entry
        {
            public string? name;
            public string[]? enabledMods;
        }

        public string? foundryFolder;
        public string? currentSelectedConfiguration;
        public Entry[]? configurations;
        public bool? testbranch;
    }
}