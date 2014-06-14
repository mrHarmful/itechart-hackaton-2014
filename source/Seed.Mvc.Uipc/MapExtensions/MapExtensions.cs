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

            surveys.User = GetUserVm();
            surveys.Questions = quizList.Questions.Items.Select(q => q.MapToSingleQuestionLblVm()).ToList();
            surveys.QuestionsPaging = new PagingVm();
            surveys.QuestionsPaging.PageNumber = quizList.Questions.PageNumber;
            surveys.QuestionsPaging.PageSize = quizList.Questions.PageSize;
            surveys.QuestionsPaging.TotalCount = quizList.Questions.TotalCount;
            surveys.Quizzes = quizList.Quizzes.Items.Select(q => q.MapToQuizLblVm()).ToList();
            surveys.QuizzesPaging = new PagingVm();
            surveys.QuizzesPaging.PageNumber = quizList.Quizzes.PageNumber;
            surveys.QuizzesPaging.PageSize = quizList.Quizzes.PageSize;
            surveys.QuizzesPaging.TotalCount = quizList.Quizzes.TotalCount;

            return surveys;
        }

        #endregion

        #region ToEntity

        #endregion

        private static SingleQuestionLblVm MapToSingleQuestionLblVm(this SingleQuestion question)
        {
            var result = new SingleQuestionLblVm();
            result.Caption = string.Format("{0}...", question.Enquiry.Take(50));
            result.Id = question.Id;

            return result;
        }

        private static QuizLblVm MapToQuizLblVm(this Quiz quiz)
        {
            var result = new QuizLblVm();
            result.Caption = string.Format("{0}...", quiz.Title.Take(50));
            result.Id = quiz.Id;
            result.QuestionsCount = quiz.Questions.Count;

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