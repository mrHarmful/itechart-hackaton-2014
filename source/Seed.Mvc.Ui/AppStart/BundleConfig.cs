using System.IO;
using System.Web.Hosting;
using System.Web.Optimization;
using dotless.Core;
using dotless.Core.configuration;
using dotless.Core.Input;
using Seed.Configuration;

namespace Seed.Web.Api
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = ConfigurationManager.Instance.EnableJsCssMinification;

            bundles.Add(
                new ScriptBundle("~/Scripts/landing-bundle")
                    .Include("~/Scripts/lib/modernizr.js"));

            bundles.Add(
                new ScriptBundle("~/Scripts/app-bundle")
                    .Include(
                        "~/Scripts/app/application.js",
                        "~/Scripts/app/routes.js")
                    .IncludeDirectory("~/Scripts/app/services/", "*.js")
                    .IncludeDirectory("~/Scripts/app/services/data/", "*.js")
                    .IncludeDirectory("~/Scripts/app/services/utils/", "*.js")
                    .IncludeDirectory("~/Scripts/app/factories/", "*.js", true)
                    .IncludeDirectory("~/Scripts/app/filters/", "*.js")
                    .IncludeDirectory("~/Scripts/app/directives/", "*.js")
                    .IncludeDirectory("~/Scripts/app/directives/events/", "*.js")
                    .IncludeDirectory("~/Scripts/app/directives/controls/", "*.js")
                    .IncludeDirectory("~/Scripts/app/directives/graphs/", "*.js")
                    .IncludeDirectory("~/Scripts/app/controllers/", "*.js")
                    .IncludeDirectory("~/Scripts/app/controllers/app", "*.js")
                    .IncludeDirectory("~/Scripts/app/controllers/views", "*.js"));

            bundles.Add(
                new ScriptBundle("~/Scripts/lib-bundle").Include(
                    "~/Scripts/lib/jquery-2.1.0.js",
                    "~/Scripts/lib/jquery.mobile.custom.js",
                    "~/Scripts/lib/jquery.validate.js",
                    "~/Scripts/lib/jquery.validate.unobtrusive.js",
                    "~/Scripts/lib/d3-3.4.5.js",
                    "~/Scripts/lib/moment-2.6.0.js",
                    "~/Scripts/lib/modernizr.js",
                    "~/Scripts/lib/angular.js",
                    "~/Scripts/lib/angular-*",
                    "~/Scripts/lib/restangular.js",
                    "~/Scripts/lib/lodash.js"));

            var less = new Bundle("~/Content/Less/less-bundle").Include("~/Content/Less/*.less");
            less.Transforms.Add(new LessTransform());
            less.Transforms.Add(new CssMinify());

            bundles.Add(less);
        }

        internal sealed class VirtualFileReader : IFileReader
        {
            public byte[] GetBinaryFileContents(string fileName)
            {
                fileName = GetFullPath(fileName);
                return File.ReadAllBytes(fileName);
            }

            public string GetFileContents(string fileName)
            {
                fileName = GetFullPath(fileName);
                return File.ReadAllText(fileName);
            }

            public bool DoesFileExist(string fileName)
            {
                fileName = GetFullPath(fileName);
                return File.Exists(fileName);
            }

            public bool UseCacheDependencies { get; private set; }

            private static string GetFullPath(string path)
            {
                return HostingEnvironment.MapPath("~/Content/Less/" + path);
            }
        }

        internal class LessTransform : IBundleTransform
        {
            public void Process(BundleContext context, BundleResponse response)
            {
                var config = new DotlessConfiguration();
                config.MinifyOutput = false;
                config.ImportAllFilesAsLess = true;
                config.CacheEnabled = false;
                config.LessSource = typeof (VirtualFileReader);

                response.Content = Less.Parse(response.Content, config);
                response.ContentType = "text/css";
            }
        }
    }
}