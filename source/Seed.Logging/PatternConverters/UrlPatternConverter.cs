using System.IO;
using System.Web;
using log4net.Layout.Pattern;

namespace Seed.Logging.PatternConverters
{
    public class UrlPatternConverter : PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, log4net.Core.LoggingEvent loggingEvent)
        {
            if (HttpContext.Current != null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.Request.Url.ToString()))
                {
                    writer.Write(HttpContext.Current.Request.Url);
                }
                else
                {
                    writer.Write("Url is not available");
                }
            }
        }
    }
}