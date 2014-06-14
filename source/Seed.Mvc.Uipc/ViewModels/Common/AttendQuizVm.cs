using System.Collections.Generic;

namespace Seed.Web.Uipc.ViewModels
{
    public class AttendQuizVm
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Reason { get; set; }

        public int QuestionsCount { get; set; }

        public List<long> QuestionsIds { get; set; }
    }
}