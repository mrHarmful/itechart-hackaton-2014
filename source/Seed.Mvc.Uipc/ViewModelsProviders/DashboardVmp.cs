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
        public static List<QuizLblVm> GetavAvailableQuizzesVm(long userId)
        {
            QuizList quizList = QuizBc.Instance.GetQuizListForAttend(userId);

            var result = quizList.MapToQuizLblListVm();

            return result;
        }

        public static void SaveAnswer(long questionId, long answerId)
        {
            QuizBc.Instance.SaveAnswer(questionId, answerId, UserBc.Instance.GetCurrntUser().Id);
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
            var result = CommonBc.Instance.GetTargets().MapToCaptionSelectList("Departments");

            return result;
        }

        public static CaptionSelectList GetPriorities()
        {
            var result = CommonBc.Instance.GetPriorities().MapToCaptionSelectList("Priority");

            return result;
        }

        public static CaptionSelectList GetCategories()
        {
            var result = CommonBc.Instance.GetCategories().MapToCaptionSelectList("Category");

            return result;
        }

        public static PointsStatusVm GetPointsStatusVm()
        {
            var points = CommonBc.Instance.CheckPoints();
            var result = new PointsStatusVm();
            if(points != null)
            {
                result.IsNeedShow = true;
                result.IsIncreased = points.IsIncreased;
                result.Change = points.Change;
                result.Total = points.Total;
            }

            return result;
        }
    }
}
