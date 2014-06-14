namespace Seed.Web.Uipc.ViewModels
{
    public class AttendQuestionVm
    {
        public long Id { get; set; }

        public bool IsSingleSelect { get; set; }

        public string Enquiry { get; set; }

        public CaptionSelectList Answers { get; set; }
    }
}