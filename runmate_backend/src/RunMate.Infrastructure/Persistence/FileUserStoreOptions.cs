namespace RunMate.Infrastructure.Persistence;

public sealed class FileUserStoreOptions
{
    public const string SectionName = "UserStore";

    public string Path { get; set; } = "App_Data/users.json";
}
