﻿using System;
using System.Collections.Generic;

namespace Seed.Web.Uipc.ViewModels
{
    public class QuestionMetaVm
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public long SelectedCategoryId { get; set; }

        public long SelectedPriorityId { get; set; }

        public CaptionSelectList SelectedTargets { get; set; }
    }
}