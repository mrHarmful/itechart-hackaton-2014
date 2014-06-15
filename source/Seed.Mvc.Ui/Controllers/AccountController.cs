using System.Web.Mvc;
using Seed.Web.Uipc;
using Seed.Web.Uipc.ViewModels;

namespace Seed.Web.Api.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogIn(string returnUrl)
        {
            LogInVm vm = ViewModelsProvider.GetLogOnVm(returnUrl);
            return View(vm);
        }

        [HttpPost]
        public ActionResult LogIn(LogInVm vm)
        {
            return Redirect("/profile");
        }

        public ActionResult LogOff()
        {
            ViewModelsProvider.LogOff();

            return RedirectToAction("Application", "Application");
        }
    }
}
