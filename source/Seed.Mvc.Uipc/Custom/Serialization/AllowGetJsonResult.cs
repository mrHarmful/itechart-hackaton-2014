using System.Web.Mvc;

namespace Seed.Web.Uipc
{
    public class AllowGetJsonResult : FormattedJsonResult
    {
        public AllowGetJsonResult(object data)
            : base(data)
        {
            JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }
    }
}