using System.Collections.Generic;
using System.Linq;
using Seed.Entities;

namespace Seed.Web.Uipc.ViewModels
{
    public class QuestionVm
    {
        public long? Id { get; set; }

        public string Enquiry { get; set; }

        public bool IsSingleSelect { get; set; }

        public List<AnswerVm> Answers { get; set; }

        public long? QuizId { get; set; }

        public bool CanSkip { get; set; }

        public bool IsUserMeta { get; set; }

        public QuestionVm()
        {
            Answers = new List<AnswerVm>();
        }

        public Question ToEntity()
        {
            var result = new Question();

            result.Answers = Answers.Select(a => a.ToEntity()).ToList();
            result.CanSkip = CanSkip;
            result.Enquiry = Enquiry;
            result.Id = Id;
            result.IsSingleSelect = IsSingleSelect;
            result.IsUserMeta = IsUserMeta;
            result.QuizId = QuizId;
            
            return result;
        }
    }
}