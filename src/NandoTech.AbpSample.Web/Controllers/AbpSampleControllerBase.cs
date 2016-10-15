using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNet.Identity;
using Abp.IdentityFramework;

namespace NandoTech.AbpSample.Web.Controllers
{
    public abstract class AbpSampleControllerBase: AbpController
    {
        protected AbpSampleControllerBase()
        {
            LocalizationSourceName = AbpSampleConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}