using System.Web.Mvc;

namespace Seed.Web.Api.Controllers
{
    public class ApplicationController : Controller
    {
        public ActionResult Application()
        {
            return View();
        }

        public ActionResult LandingPage()
        {
            return View();
        }
    }
}
