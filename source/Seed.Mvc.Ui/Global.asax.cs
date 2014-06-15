using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
using Seed.Logging;

namespace Seed.Web.Api
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_PostAuthorizeRequest()
        {
            if (IsWebApiRequest())
            {
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            }
        }

        public void Application_AcquireRequestState(object sender, EventArgs e)
        {
            var currentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = currentCulture;
            Thread.CurrentThread.CurrentUICulture = currentCulture;
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinderConfig.RegisterModelBinders(ModelBinders.Binders);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;

            var exception = context.Server.GetLastError() as HttpException;

            if (exception != null && exception.GetHttpCode() == 404)
            {
                Logger.Error(exception.Message, exception);
            }
        }

        private bool IsWebApiRequest()
        {
            return HttpContext.Current != null
                   && HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath != null
                   && HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.StartsWith("~/api");
        }
    }
}