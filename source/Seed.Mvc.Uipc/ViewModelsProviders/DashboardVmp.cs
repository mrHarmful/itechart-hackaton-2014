using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Seed.Bcs;
using Seed.Entities.AccountItems;
using Seed.Web.Uipc.ViewModels;

namespace Seed.Web.Uipc
{
    public static partial class ViewModelsProvider
    {
        public static SurveysVm GetSurveysVm(long userId)
        {
            UserQuizList quizList = QuizBc.Instance.GetQuizList(userId);

            var result = quizList.MapToSurveysVm();

            return result;
        }

        public static QuizVm GetQuizVm(long quizId)
        {
            var quiz = QuizBc.Instance.GetQuiz(quizId);

            var result = quiz.MapToQuizVm();

            return result;
        }

        public static List<SelectListItem> GetTargets()
        {
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

            return list;
        }

        public static List<SelectListItem> GetPriorities()
        {
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

            return list;
        }

        public static List<SelectListItem> GetCategories()
        {
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

            return list;
        }
    }
}
