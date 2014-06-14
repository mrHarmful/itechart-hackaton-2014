using System.Collections.Generic;

namespace Seed.Web.Uipc.ViewModels
{
    public class QuizVm
    {
        public long? Id { get; set; }

        public QuizMetaVm Meta { get; set; }

        public List<QuestionVm> Questions { get; set; }
    }
}