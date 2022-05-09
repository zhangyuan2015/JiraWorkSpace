using JiraWorkSpace.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace JiraWorkSpace.Permissions;

public class JiraWorkSpacePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(JiraWorkSpacePermissions.GroupName, L("Permission:JiraWorkSpace"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<JiraWorkSpaceResource>(name);
    }
}
