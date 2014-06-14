using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Seed.Utilities;
using Seed.Web.Uipc.ViewModels;

namespace Seed.Web.Uipc
{
    public static partial class ViewModelsProvider
    {

        public static LogInVm GetLogOnVm(string returnUrl)
        {
            var vm = new LogInVm();

            var helper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string indexUrl = helper.Action("Application", "Application");

            vm.ReturnUrl = returnUrl.IsNullOrEmpty() ? indexUrl : returnUrl;

            return vm;
        }

        public static bool LogOn(LogInVm vm)
        {
            if (vm == null)
            {
                return false;
            }
            if (Membership.ValidateUser(vm.UserName, vm.Password))
            {
                FormsAuthentication.SetAuthCookie(vm.UserName, vm.RememberMe);
                return true;
            }
            vm.ErrorMessage = "Wrong username or password.";
            return false;
        }

        public static void LogOff()
        {
            FormsAuthentication.SignOut();
        }
    }
}