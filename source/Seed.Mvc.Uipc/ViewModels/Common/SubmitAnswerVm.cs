using System.Collections.Generic;

namespace Seed.Web.Uipc.ViewModels
{
    public class SubmitAnswerVm
    {
        public long QuestionId { get; set; }

        public List<long> AnswersIds { get; set; }
    }
}