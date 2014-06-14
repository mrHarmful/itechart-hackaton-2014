using System.Web.Http;
using Seed.Web.Uipc;
using Seed.Web.Uipc.ViewModels;

namespace Seed.Web.Api.Controllers
{
    public class SurveysController : ApiController
    {
        [Route("api/surveys")]
        public SurveysVm GetUserSurveys()
        {
            var result = ViewModelsProvider.GetSurveysVm(0);

            return result;
        }
    }
}
