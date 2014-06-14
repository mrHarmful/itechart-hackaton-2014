using System.Collections.Generic;

namespace Seed.Web.Uipc.ViewModels
{
    public class LocalizationVm
    {
        public Dictionary<string, string> Enums { get; set; }

        public Dictionary<string, string> ErrorMessages { get; set; }

        public LocalizationVm()
        {
            Enums = new Dictionary<string, string>();
            ErrorMessages = new Dictionary<string, string>();
        }
    }
}