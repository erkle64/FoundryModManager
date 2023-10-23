namespace FoundryModManager
{
    public class RepositoryData
    {
        public class Entry
        {
            public string? name;
            public string? folder;
            public string? url;
            public string? home;
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
