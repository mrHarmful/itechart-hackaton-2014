using System.Web.Http;
using Seed.Web.Uipc;
using Seed.Web.Uipc.ViewModels;

namespace Seed.Web.Api.Controllers
{
    public class MiscController : ApiController
    {
        [Route("api/targets")]
        public CaptionSelectList GetTargets()
        {
            var result = ViewModelsProvider.GetTargets();

            return result;
        }

        [Route("api/priorities")]
        public CaptionSelectList GetPriorities()
        {
            var result = ViewModelsProvider.GetPriorities();

            return result;
        }

        [Route("api/categories")]
        public CaptionSelectList GetCategories()
        {
            var result = ViewModelsProvider.GetCategories();

            return result;
        }
    }
}
