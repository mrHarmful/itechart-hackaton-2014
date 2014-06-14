using System.Collections.Generic;
using System.Linq;
using Seed.Entities;

namespace Seed.Web.Uipc.ViewModels
{
    public class QuizVm
    {
        public long? Id { get; set; }

        public QuizMetaVm Meta { get; set; }

        public List<QuestionVm> Questions { get; set; }

        public Quiz ToEntity()
        {
            var result = new Quiz();

            result.CategoryId = Meta.SelectedCategoryId;
            result.EndDate = Meta.EndDate;
            result.Id = Id;
            result.PriorityId = Meta.SelectedPriorityId;
            result.Questions = Questions.Select(q => q.ToEntity()).ToList();
            result.Reason = Meta.Reason;
            result.StartDate = Meta.StartDate;
            result.Targets = Meta.SelectedTargetIds;
            result.Title = Meta.Title;

            return result;
        }
    }
}