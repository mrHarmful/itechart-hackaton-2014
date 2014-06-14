using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Seed.Utilities;

namespace Seed.Web.Uipc
{
    public class FormattedJsonResult : JsonResult
    {
        public FormattedJsonResult(object data)
        {
            Data = data;
            JsonRequestBehavior = JsonRequestBehavior.DenyGet;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = ContentType.IsNullOrEmpty() ? "application/json" : ContentType;

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if (Data != null)
            {
                string json = JsonConvert.SerializeObject(Data,
                                                          Formatting.Indented,
                                                          new JsonSerializerSettings
                                                          {
                                                              ContractResolver =
                                                                  new CamelCasePropertyNamesContractResolver()
                                                          });

                response.Write(json);
            }
        }
    }
}