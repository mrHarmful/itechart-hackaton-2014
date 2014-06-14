using System.IO;
using System.Web;
using log4net.Layout.Pattern;

namespace Seed.Logging.PatternConverters
{
    public class ReferrerUrlPatternConverter : PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, log4net.Core.LoggingEvent loggingEvent)
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Request.UrlReferrer != null && !string.IsNullOrEmpty(HttpContext.Current.Request.UrlReferrer.AbsoluteUri))
                {
                    writer.Write(HttpContext.Current.Request.UrlReferrer.AbsoluteUri);
                }
                else
                {
                    writer.Write("Referrer url is not available");
                }
            }
        }
    }
}