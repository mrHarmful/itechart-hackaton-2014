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

        public ActionResult LogIn(LogInVm vm)
        {
            var isAuth = ViewModelsProvider.LogOn(vm);

            if (isAuth)
            {
                if (Url.IsLocalUrl(vm.ReturnUrl))
                {
                    return Redirect(vm.ReturnUrl);
                }
                return RedirectToAction("Application", "Application");
            }

            return View(vm);
        }

        public ActionResult LogOff()
        {
            ViewModelsProvider.LogOff();

            return RedirectToAction("Application", "Application");
        }
    }
}
