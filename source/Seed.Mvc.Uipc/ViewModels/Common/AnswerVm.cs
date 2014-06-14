using Seed.Entities;

namespace Seed.Web.Uipc.ViewModels
{
    public class AnswerVm
    {
        public long? Id { get; set; }

        public long QuestionId { get; set; }

        public string Caption { get; set; }

        public Answer ToEntity()
        {
            var result = new Answer();

            result.Id = Id;
            result.QuestionId = QuestionId;
            result.Caption = Caption;

            return result;
        }
    }
}