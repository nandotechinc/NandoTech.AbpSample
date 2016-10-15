using Abp.AspNetCore.Mvc.Authorization;
using NandoTech.AbpSample.Authorization;
using NandoTech.AbpSample.MultiTenancy;
using Microsoft.AspNetCore.Mvc;

namespace NandoTech.AbpSample.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : AbpSampleControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}