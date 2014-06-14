using System.Globalization;
using System.Web.Http;
using Seed.Web.Uipc;
using Seed.Web.Uipc.ViewModels;

namespace Seed.Web.Api.Controllers
{
    public class ConfigurationController : ApiController
    {
        [Route("api/localization/{culture}")]
        public LocalizationVm GetLocalization(string culture = "en-us")
        {
            var cultureInfo = CultureInfo.GetCultureInfo(culture);
            var result = ViewModelsProvider.GetLocalizationVm(cultureInfo);

            return result;
        }
    }
}
