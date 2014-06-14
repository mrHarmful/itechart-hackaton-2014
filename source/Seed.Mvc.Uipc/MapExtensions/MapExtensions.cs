using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Seed.Bcs;
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

        public static CaptionSelectList MapToCaptionSelectList(this List<KeyValueItem> items, string caption)
        {
            var result = new CaptionSelectList();

            result.Caption = caption;
            result.Items = new List<SelectListItem>();

            foreach (var item in items)
            {
                var slItem = new SelectListItem();
                slItem.Selected = false;
                slItem.Text = item.Caption;
                slItem.Value = item.Id.ToString();
            }

            return result;
        }

        public static SingleQuestionVm MapSingleQuestionVm(this SingleQuestion question)
        {
            var result = new SingleQuestionVm();

            result.Id = question.Id;
            result.Meta = new QuizMetaVm();
            result.Meta.EndDate = question.EndDate;
            result.Meta.SelectedCategoryId = question.CategoryId;
            result.Meta.SelectedPriorityId = question.PriorityId;
            result.Meta.Targets =
                CommonBc.Instance.GetTargets().Where(t => question.Targets.Contains(t.Id)).ToList().
                    MapToCaptionSelectList("Departments");
            result.Meta.StartDate = question.StartDate;
            result.Question = new QuestionVm();
            result.Question.Enquiry = question.Enquiry;
            result.Question.CanSkip = question.CanSkip;
            result.Question.Id = question.Id;
            result.Question.IsUserMeta = question.IsUserMeta;
            result.Question.QuizId = null;
            result.Question.IsSingleSelect = question.IsSingleSelect;
            result.Question.Answers = new List<AnswerVm>();

            foreach (var answer in question.Answers)
            {
                var aVm = new AnswerVm();
                aVm.Id = answer.Id;
                aVm.Caption = answer.Caption;
                aVm.QuestionId = question.Id.Value;
            }

            return result;
        }

        public static QuizVm MapToQuizVm(this Quiz quiz)
        {
            var result = new QuizVm();

            result.Id = quiz.Id;
            result.Meta = new QuizMetaVm();
            result.Meta.EndDate = quiz.EndDate;
            result.Meta.Reason = quiz.Reason;
            result.Meta.SelectedCategoryId = quiz.CategoryId;
            result.Meta.SelectedPriorityId = (int) quiz.PriorityId;
            result.Meta.Targets =
                CommonBc.Instance.GetTargets().Where(t => quiz.Targets.Contains(t.Id)).ToList().MapToCaptionSelectList(
                    "Departments");
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
                qVm.IsSingleSelect = question.IsSingleSelect;
                qVm.Answers = new List<AnswerVm>();

                foreach (var answer in question.Answers)
                {
                    var aVm = new AnswerVm();
                    aVm.Id = answer.Id;
                    aVm.Caption = answer.Caption;
                    aVm.QuestionId = question.Id.Value;
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
            result.Enquiry = question.Enquiry;
            result.Id = question.Id.Value;
            result.Category = "Development";//SampleBc.Instance.GetCategories().First(c => c.Id == question.CategoryId).Caption;
            result.Target = "D1; D2";/*string.Join(";",
                                        SampleBc.Instance.GetTargets().Where(t => question.Targets.Contains(t.Id)).Select(
                                            t => t.Caption));*/
            result.Priority = "Hot";//SampleBc.Instance.GetPriorities().First(p => p.Id == question.PriorityId).Caption;

            return result;
        }

        private static QuizLblVm MapToQuizLblVm(this Quiz quiz)
        {
            var result = new QuizLblVm();
            result.Enquiry = quiz.Title;
            result.Id = quiz.Id.Value;
            result.Category = "Development";//SampleBc.Instance.GetCategories().First(c=>c.Id == quiz.CategoryId).Caption;
            result.Target = "D1; D2"; /*string.Join(";",
                                        SampleBc.Instance.GetTargets().Where(t => quiz.Targets.Contains(t.Id)).Select(
                                            t => t.Caption));*/
            result.QuestionsCount = quiz.Questions.Count;
            result.Priority = "Hot";//SampleBc.Instance.GetPriorities().First(p => p.Id == quiz.PriorityId).Caption;

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