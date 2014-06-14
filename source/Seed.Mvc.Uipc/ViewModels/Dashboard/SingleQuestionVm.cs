using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seed.Entities;

namespace Seed.Web.Uipc.ViewModels
{
    public class SingleQuestionVm
    {
        public long? Id { get; set; }

        public QuestionMetaVm Meta { get; set; }

        public QuestionVm Question { get; set; }

        public SingleQuestion ToEntity()
        {
            var result = new SingleQuestion();

            result.CategoryId = Meta.SelectedCategoryId;
            result.EndDate = Meta.EndDate;
            result.Id = Id;
            result.PriorityId = Meta.SelectedPriorityId;
            result.StartDate = Meta.StartDate;
            result.Targets = Meta.Targets.Items.Where(t => t.Selected).Select(t => long.Parse(t.Value)).ToList(); ;
            result.Answers = Question.Answers.Select(a => a.ToEntity()).ToList();
            result.CanSkip = Question.CanSkip;
            result.Enquiry = Question.Enquiry;
            result.Id = Id;
            result.IsSingleSelect = Question.IsSingleSelect;
            result.IsUserMeta = Question.IsUserMeta;
            result.QuizId = null;

            return result;
        }
    }
}
