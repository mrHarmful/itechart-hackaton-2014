using System.Collections.Generic;

namespace Seed.Web.Uipc.ViewModels
{
    public class SurveysVm : DashboardVm
    {
        public List<SingleQuestionLblVm> Questions { get; set; }

        public PagingVm QuestionsPaging { get; set; }

        public List<QuizLblVm> Quizzes { get; set; }

        public PagingVm QuizzesPaging { get; set; }
    }
}