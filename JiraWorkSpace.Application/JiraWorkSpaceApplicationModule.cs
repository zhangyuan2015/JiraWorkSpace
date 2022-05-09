using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace JiraWorkSpace;

[DependsOn(
    typeof(JiraWorkSpaceDomainModule),
    typeof(JiraWorkSpaceApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class JiraWorkSpaceApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<JiraWorkSpaceApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<JiraWorkSpaceApplicationModule>(validate: true);
        });
    }
}
