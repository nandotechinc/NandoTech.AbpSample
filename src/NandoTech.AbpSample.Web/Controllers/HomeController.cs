using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NandoTech.AbpSample.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : AbpSampleControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}