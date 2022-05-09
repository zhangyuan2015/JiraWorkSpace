using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using JiraWorkSpace.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace JiraWorkSpace;

[DependsOn(
    typeof(AbpValidationModule)
)]
public class JiraWorkSpaceDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<JiraWorkSpaceDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<JiraWorkSpaceResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/JiraWorkSpace");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("JiraWorkSpace", typeof(JiraWorkSpaceResource));
        });
    }
}
