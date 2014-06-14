using System.Collections.Generic;
using System.Web.Http;
using Seed.Web.Uipc;
using Seed.Web.Uipc.ViewModels;

namespace Seed.Web.Api.Controllers
{
    public class QuestionsController : ApiController
    {
        [Route("api/questions/{id}")]
        public AttendQuestionVm GetAttendQuestion(long id)
        {
            var result = ViewModelsProvider.GetAttendQuizQuestionVm(id);

            return result;
        }

        [Route("api/questions/{questionId}/answer")]
        public void PutAnswer(SubmitAnswerVm vm)
        {
            foreach (var answerId in vm.AnswersIds)
            {
                ViewModelsProvider.SaveAnswer(vm.QuestionId, answerId);
            }
        }
    }
}
