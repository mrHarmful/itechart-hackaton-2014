using System.Collections.Generic;
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

        [Route("api/surveys/available")] 
        public List<QuizLblVm> GetAvailableSurveys()
        {
            var result = ViewModelsProvider.GetavAvailableQuizzesVm(0);

            return result;
        }

        [Route("api/surveys/quiz")]
        public void PutSurvey(QuizVm vm)
        {
            ViewModelsProvider.SaveQuiz(vm);
        }
        
        [Route("api/surveys/single-question")]
        public void PutSingleQuestion(SingleQuestionVm vm)
        {
            ViewModelsProvider.SaveSingleQuestion(vm);
        }

        [Route("api/surveys/{id:long}/quiz")]
        public QuizVm GetQuiz(long id)
        {
            var result = ViewModelsProvider.GetQuizVm(id);

            return result;
        }

        [Route("api/surveys/{id:long}/single-question")]
        public SingleQuestionVm GetSingleQuestion(long id)
        {
            var result = ViewModelsProvider.GetSingleQuestionVm(id);

            return result;
        }

        [Route("api/surveys/{id:long}/attend")]
        public AttendQuizVm GetAttendQuiz(long id)
        {
            var result = ViewModelsProvider.GetAttendQuizVm(id);

            return result;
        }

        [Route("api/points/status")]
        public PointsStatusVm GetPointsStatus()
        {
            var result = ViewModelsProvider.GetPointsStatusVm();

            return result;
        }
    }
}
