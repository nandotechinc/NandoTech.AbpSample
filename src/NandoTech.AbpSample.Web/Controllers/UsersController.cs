using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using NandoTech.AbpSample.Authorization;
using NandoTech.AbpSample.Users;
using Microsoft.AspNetCore.Mvc;

namespace NandoTech.AbpSample.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : AbpSampleControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _userAppService.GetUsers();
            return View(output);
        }
    }
}