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

        [Route("api/surveys")]
        public void PutSurvey(QuizVm vm)
        {
            ViewModelsProvider.SaveQuiz(vm);
        }

        [Route("api/surveys/{id:long}")]
        public QuizVm GetQuiz(long id)
        {
            var result = ViewModelsProvider.GetQuizVm(id);

            return result;
        }
    }
}
