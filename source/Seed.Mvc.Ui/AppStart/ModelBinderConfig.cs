using System.Web.Mvc;
using Seed.Web.Uipc;
using Seed.Web.Uipc.ViewModels;

namespace Seed.Web.Api
{
    public class ModelBinderConfig
    {
        public static void RegisterModelBinders(ModelBinderDictionary binders)
        {
            binders.Add(typeof (AddressVm), new AddressVmBinder());
        }
    }
}