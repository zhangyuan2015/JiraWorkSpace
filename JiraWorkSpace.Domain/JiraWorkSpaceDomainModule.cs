using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace JiraWorkSpace;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(JiraWorkSpaceDomainSharedModule)
)]
public class JiraWorkSpaceDomainModule : AbpModule
{

}
