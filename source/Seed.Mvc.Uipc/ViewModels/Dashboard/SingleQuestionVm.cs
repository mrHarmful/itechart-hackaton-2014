﻿using System.Linq;
using Seed.Bcs;
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

            result.OwnerId = UserBc.Instance.GetCurrntUser().Id;
            result.CategoryId = Meta.SelectedCategoryId;
            result.EndDate = Meta.EndDate;
            result.Id = Id;
            result.PriorityId = Meta.SelectedPriorityId;
            result.StartDate = Meta.StartDate;
            result.Targets = Meta.SelectedTargets.Items.Where(t => t.Selected).Select(t => long.Parse(t.Value)).ToList(); ;
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
