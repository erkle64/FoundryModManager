namespace FoundryModManager
{
    public class RepositoryData
    {
        public class Entry
        {
            public string? name;
            public string? folder;
            public string? url;
            public string? url_testbranch;
            public Dictionary<string, string>? versions;
            public string? home;
            public string? config;
            public string? author;
            public string? description;
            public string[]? requirements;

            public override string ToString() => name ?? "unnamed";
        }

        public Entry[]? repositories;
    }

    public class SourcesData
    {
        public string[]? sources;
    }
}
