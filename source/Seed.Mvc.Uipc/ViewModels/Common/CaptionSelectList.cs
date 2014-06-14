using System.Collections.Generic;
using System.Web.Mvc;

namespace Seed.Web.Uipc.ViewModels
{
    public class CaptionSelectList
    {
        public List<SelectListItem> Items { get; set; }

        public string Caption { get; set; }
    }
}
