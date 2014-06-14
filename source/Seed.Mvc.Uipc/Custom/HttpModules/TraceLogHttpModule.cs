using System;
using System.Text.RegularExpressions;
using System.Web;
using Seed.Configuration;
using Seed.Logging;

namespace Seed.Web.Uipc
{
    public class TraceLogHttpModule : IHttpModule
    {
        #region Private constants

        private const string BeginRequestLogMessage =
            "TRACE LOG - REQUEST KEY: {0}. PHASE: BEGIN HTTP REQUEST.\r\n\t'{1}' request received at {2}.";

        private const string EndRequestLogMessage =
            "TRACE LOG - REQUEST KEY: {0}. PHASE: END HTTP REQUEST. DURATION: {1} sec.\r\n\t'{2}' response sent at {3}.";

        private const string BeginRequestErrorMessageWithUrl = "Error during begin '{0}' http request";

        private const string BeginRequestErrorMessage = "Error during begin http request";

        private const string EndRequestErrorMessageWithUrl = "Error during end '{0}' http request";

        private const string EndRequestErrorMessage = "Error during end http request";

        private const string BeginRequest = "LmsHttpBeginRequestTime";

        private const string WhiteListPattern = @"^(/api/|/scripts/|/content/)";

        #endregion

        #region Public methods

        public void Init(HttpApplication application)
        {
            application.BeginRequest += BeginRequestLog;
            application.EndRequest += EndRequestLog;
        }

        public void Dispose() {}

        #endregion

        #region Private methods

        private void BeginRequestLog(object sender, EventArgs e)
        {
            HttpContext httpContext = null;

            try
            {
                if (sender != null)
                {
                    httpContext = ((HttpApplication) sender).Context;

                    if (httpContext != null
                        && !Regex.IsMatch(httpContext.Request.Url.AbsolutePath,
                                          WhiteListPattern,
                                          RegexOptions.IgnoreCase)
                        && ConfigurationManager.Instance.IsEnableTraceLogging)
                    {
                        Guid requestKey = Guid.NewGuid();
                        DateTime beginRequest = DateTime.Now;

                        Logger.InfoFormat(BeginRequestLogMessage,
                                          requestKey,
                                          httpContext.Request.Url,
                                          beginRequest.ToLongTimeString());

                        httpContext.Items[ConfigurationManager.Instance.RequestKeyContextItemName] = requestKey;
                        httpContext.Items[BeginRequest] = beginRequest;
                    }
                }
            }
            catch (Exception ex)
            {
                if (httpContext != null)
                {
                    Logger.ErrorFormat(BeginRequestErrorMessageWithUrl, ex, httpContext.Request.Url);
                }
                else
                {
                    Logger.ErrorFormat(BeginRequestErrorMessage, ex);
                }
            }
        }

        private void EndRequestLog(object sender, EventArgs e)
        {
            HttpContext httpContext = null;

            try
            {
                if (sender != null)
                {
                    httpContext = ((HttpApplication) sender).Context;

                    if (httpContext != null
                        && !Regex.IsMatch(httpContext.Request.Url.AbsolutePath,
                                          WhiteListPattern,
                                          RegexOptions.IgnoreCase)
                        && ConfigurationManager.Instance.IsEnableTraceLogging)
                    {
                        Guid? requestKey =
                            httpContext.Items.Contains(ConfigurationManager.Instance.RequestKeyContextItemName)
                                ? (Guid?) httpContext.Items[ConfigurationManager.Instance.RequestKeyContextItemName]
                                : null;
                        DateTime beginRequest = httpContext.Items.Contains(BeginRequest)
                            ? (DateTime) httpContext.Items[BeginRequest]
                            : DateTime.MinValue;
                        DateTime endRequest = DateTime.Now;

                        Logger.InfoFormat(EndRequestLogMessage,
                                          requestKey,
                                          (endRequest - beginRequest).TotalSeconds,
                                          httpContext.Request.Url,
                                          DateTime.Now.ToLongTimeString());
                    }
                }
            }
            catch (Exception ex)
            {
                if (httpContext != null)
                {
                    Logger.ErrorFormat(EndRequestErrorMessageWithUrl, ex, httpContext.Request.Url);
                }
                else
                {
                    Logger.ErrorFormat(EndRequestErrorMessage, ex);
                }
            }
        }

        #endregion
    }
}