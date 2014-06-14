using System.Linq;
using Seed.Entities;
using Seed.Entities.AccountItems;
using Seed.Web.Uipc.ViewModels;

namespace Seed.Web.Uipc
{
    internal static class MapExtensions
    {
        #region ToVm

        public static SurveysVm MapToSurveysVm(this UserQuizList quizList)
        {
            var surveys = new SurveysVm();
            surveys.Questions = quizList.Questions.Select(q => q.MapToSingleQuestionLblVm()).ToList();
            surveys.Quizzes = quizList.Quizzes.Select(q => q.MapToQuizLblVm()).ToList();

            return surveys;
        }

        #endregion

        #region ToEntity

        #endregion

        private static SingleQuestionLblVm MapToSingleQuestionLblVm(this SingleQuestion question)
        {
            var result = new SingleQuestionLblVm();
            result.Enquiry = string.Format("{0}...", question.Enquiry.Take(50));
            result.Id = question.Id;
            result.Category = question.Category.Title;
            result.Target = string.Join(";", question.Target.Select(t => t.Name));
            result.Priority = question.Priority.ToString();

            return result;
        }

        private static QuizLblVm MapToQuizLblVm(this Quiz quiz)
        {
            var result = new QuizLblVm();
            result.Enquiry = string.Format("{0}...", quiz.Title.Take(50));
            result.Id = quiz.Id;
            result.Category = quiz.Category.Title;
            result.Target = string.Join(";", quiz.Target.Select(t => t.Name));
            result.QuestionsCount = quiz.Questions.Count;
            result.Priority = quiz.Priority.ToString();

            return result;
        }

        private static UserVm GetUserVm()
        {
            var user = new UserVm();
            user.FirstName = "John";
            user.LastName = "Doe";
            user.UserName = "john.doe";
            user.Id = -1;

            return user;
        }
    }
}