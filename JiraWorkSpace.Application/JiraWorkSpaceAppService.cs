using JiraWorkSpace.Localization;
using Volo.Abp.Application.Services;

namespace JiraWorkSpace;

public abstract class JiraWorkSpaceAppService : ApplicationService
{
    protected JiraWorkSpaceAppService()
    {
        LocalizationResource = typeof(JiraWorkSpaceResource);
        ObjectMapperContext = typeof(JiraWorkSpaceApplicationModule);
    }
}
