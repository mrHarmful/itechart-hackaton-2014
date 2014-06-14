using System.ComponentModel;
using System.Web.Mvc;
using Seed.Web.Uipc.ViewModels;

namespace Seed.Web.Uipc
{
    public class AddressVmBinder : DefaultModelBinder
    {
        protected override void BindProperty(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext,
            PropertyDescriptor propertyDescriptor)
        {
            var model = bindingContext.Model as AddressVm;

            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);

            if (model != null)
            {
                BindSearchModel(model, controllerContext, propertyDescriptor);
            }
        }

        protected void BindSearchModel(
            AddressVm model,
            ControllerContext controllerContext,
            PropertyDescriptor propertyDescriptor)
        {
            if (string.Equals(propertyDescriptor.Name, "State"))
            {
                string countryCodeStr = (string) controllerContext.RouteData.Values["countryCode"]
                                        ?? controllerContext.HttpContext.Request["CountryCode"];

                model.CountryCode = countryCodeStr;
            }
        }
    }
}