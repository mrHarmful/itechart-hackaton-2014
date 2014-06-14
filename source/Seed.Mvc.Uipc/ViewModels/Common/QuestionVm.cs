using System.Collections.Generic;

namespace Seed.Web.Uipc.ViewModels
{
    public class QuestionVm
    {
        public long? Id { get; set; }

        public string Enquiry { get; set; }

        public int SelectedTypeId { get; set; }

        public List<AnswerVm> Answers { get; set; }

        public long? QuizId { get; set; }

        public bool CanSkip { get; set; }

        public bool IsUserMeta { get; set; }

        public QuestionVm()
        {
            Answers = new List<AnswerVm>();
        }
    }
}