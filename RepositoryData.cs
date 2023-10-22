namespace FoundryModManager
{
    public class RepositoryData
    {
        public class Entry
        {
            public string? name;
            public string? folder;
            public string? url;
            public string[]? requirements;

            public override string ToString() => name ?? "unnamed";
        }

        public Entry[]? repositories;
    }
}
