using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
