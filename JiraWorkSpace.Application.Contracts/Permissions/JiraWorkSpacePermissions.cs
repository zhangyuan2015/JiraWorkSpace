using Volo.Abp.Reflection;

namespace JiraWorkSpace.Permissions;

public class JiraWorkSpacePermissions
{
    public const string GroupName = "JiraWorkSpace";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(JiraWorkSpacePermissions));
    }
}
