using System.Collections.Generic;

namespace Seed.Web.Uipc.ViewModels
{
    public class SurveysVm
    {
        public List<SingleQuestionLblVm> Questions { get; set; }

        public List<QuizLblVm> Quizzes { get; set; }
    }
}