using System.Collections.Generic;
using System.Web.Mvc;
using Seed.Bcs;
using Seed.Entities;
using Seed.Entities.AccountItems;
using Seed.Web.Uipc.ViewModels;

namespace Seed.Web.Uipc
{
    public static partial class ViewModelsProvider
    {
        public static List<QuizLblVm> GetavAilableQuizzesVm(long userId)
        {
            QuizList quizList = QuizBc.Instance.GetQuizListForAttend(userId);

            var result = quizList.MapToQuizLblListVm();

            return result;
        }

        public static AttendQuizVm GetAttendQuizVm(long quizId)
        {
            var quiz = QuizBc.Instance.GetQuiz(quizId);

            var result = quiz.MapToAttendQuizVm();

            return result;
        }

        public static AttendQuestionVm GetAttendQuizQuestionVm(long questionId)
        {
            Question question = QuizBc.Instance.GetQuestion(questionId);

            var result = question.MapToAttendQuizQuestionVm();

            return result;
        }

        public static AttendQuestionVm GetAttendSingleQuestionVm(long userId)
        {
            Question question = QuizBc.Instance.GetRamdomSingleQuestionForUser(userId);

            var result = question.MapToAttendQuizQuestionVm();

            return result;
        }

        public static SurveysVm GetSurveysVm(long userId)
        {
            UserQuizList quizList = QuizBc.Instance.GetQuizList(userId);

            var result = quizList.MapToSurveysVm();

            return result;
        }

        public static void SaveSingleQuestion(SingleQuestionVm vm)
        {
            var result = vm.ToEntity();

            QuizBc.Instance.SaveSingleQuestion(result);
        }

        public static void SaveQuiz(QuizVm vm)
        {
            var result = vm.ToEntity();

            QuizBc.Instance.SaveQuiz(result);
        }

        public static SingleQuestionVm GetSingleQuestionVm(long questionId)
        {
            SingleQuestion question = QuizBc.Instance.GetSingleQuestion(questionId);

            var result = question.MapSingleQuestionVm();

            return result;
        }

        public static QuizVm GetQuizVm(long quizId)
        {
            var quiz = QuizBc.Instance.GetQuiz(quizId);

            var result = quiz.MapToQuizVm();

            return result;
        }

        public static CaptionSelectList GetTargets()
        {
            var result = new CaptionSelectList();
            result.Caption = "Departments";
            var list = new List<SelectListItem>();

            var item1 = new SelectListItem();
            item1.Selected = false;
            item1.Text = "D1";
            item1.Value = "1";

            list.Add(item1);

            var item2 = new SelectListItem();
            item2.Selected = false;
            item2.Text = "D2";
            item2.Value = "2";

            list.Add(item2);
            result.Items = list;

            //var result = SampleBc.Instance.GetTargets().MapToCaptionSelectList("Departments");

            return result;
        }

        public static CaptionSelectList GetPriorities()
        {
            var result = new CaptionSelectList();
            result.Caption = "Priority";
            var list = new List<SelectListItem>();

            var item1 = new SelectListItem();
            item1.Selected = false;
            item1.Text = "Hot";
            item1.Value = "1";

            list.Add(item1);

            var item2 = new SelectListItem();
            item2.Selected = false;
            item2.Text = "Medium";
            item2.Value = "2";

            list.Add(item2);

            result.Items = list;

            //var result = SampleBc.Instance.GetPriorities().MapToCaptionSelectList("Priority");

            return result;
        }

        public static CaptionSelectList GetCategories()
        {
            var result = new CaptionSelectList();
            result.Caption = "Category";
            var list = new List<SelectListItem>();

            var item1 = new SelectListItem();
            item1.Selected = false;
            item1.Text = "Work";
            item1.Value = "1";

            list.Add(item1);

            var item2 = new SelectListItem();
            item2.Selected = false;
            item2.Text = "Health";
            item2.Value = "2";

            list.Add(item2);

            result.Items = list;

            //var result = SampleBc.Instance.GetCategories().MapToCaptionSelectList("Category");

            return result;
        }
    }
}
