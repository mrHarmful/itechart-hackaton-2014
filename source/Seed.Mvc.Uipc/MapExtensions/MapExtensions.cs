using System.Collections.Generic;
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

        public static QuizVm MapToQuizVm(this Quiz quiz)
        {
            var result = new QuizVm();

            result.Id = quiz.Id;
            result.Meta = new QuizMetaVm();
            result.Meta.EndDate = quiz.EndDate;
            result.Meta.Reason = quiz.Reason;
            result.Meta.SelectedCategoryId = quiz.Category.Id;
            result.Meta.SelectedPriorityId = (int) quiz.Priority;
            result.Meta.SelectedTargetIds = quiz.Target.Select(t => t.Id).ToList();
            result.Meta.StartDate = quiz.StartDate;
            result.Meta.Title = quiz.Title;
            result.Questions = new List<QuestionVm>();

            foreach (var question in quiz.Questions)
            {
                var qVm = new QuestionVm();
                qVm.Enquiry = question.Enquiry;
                qVm.CanSkip = question.CanSkip;
                qVm.Id = question.Id;
                qVm.IsUserMeta = question.IsUserMeta;
                qVm.QuizId = quiz.Id;
                qVm.SelectedTypeId = (int) question.Type;
                qVm.Answers = new List<AnswerVm>();

                foreach (var answer in question.Answers)
                {
                    var aVm = new AnswerVm();
                    aVm.Id = answer.Id;
                    aVm.Caption = answer.Caption;
                    aVm.QuestionId = question.Id;
                }
            }

            return result;
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