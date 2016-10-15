using Microsoft.AspNetCore.Mvc;

namespace NandoTech.AbpSample.Web.Controllers
{
    public class AboutController : AbpSampleControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}