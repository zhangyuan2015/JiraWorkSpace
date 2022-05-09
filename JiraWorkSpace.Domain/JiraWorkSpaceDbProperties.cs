namespace JiraWorkSpace;

public static class JiraWorkSpaceDbProperties
{
    public static string DbTablePrefix { get; set; } = "JiraWorkSpace";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "JiraWorkSpace";
}
