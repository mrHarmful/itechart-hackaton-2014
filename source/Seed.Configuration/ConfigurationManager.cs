using System;
using System.Collections.Generic;
using System.Globalization;
using Seed.Logging;
using SystemConfigurationManager = System.Configuration.ConfigurationManager;

namespace Seed.Configuration
{
    public class ConfigurationManager
    {
        #region Singleton

        private static ConfigurationManager _configurationManager;

        private static readonly object Locker;

        static ConfigurationManager()
        {
            Locker = new object();
        }

        private ConfigurationManager()
        {
            Init();
        }

        public static ConfigurationManager Instance
        {
            get
            {
                if (_configurationManager == null)
                {
                    lock (Locker)
                    {
                        if (_configurationManager == null)
                        {
                            _configurationManager = new ConfigurationManager();
                        }
                    }
                }

                return _configurationManager;
            }
        }

        #endregion

        #region Public properties

        #region App settings

        public string DacFactoryFullTypeName { get; private set; }

        public string SeedConnectionString { get; private set; }

        public bool IsEnableTraceLogging { get; private set; }

        public string RequestKeyContextItemName { get; private set; }

        public int SqlCommandTimeoutSeconds { get; private set; }

        public bool EnableJsCssMinification { get; private set; }

        #endregion

        #region Database related configuration

        public Dictionary<int, List<string>> CompetitiveItems { get; set; }

        #endregion

        #endregion

        #region Private methods

        private void Init()
        {
            DacFactoryFullTypeName = "Lms.Dacs.MsSql.MsSqlDacFactory";
            SeedConnectionString = SystemConfigurationManager.ConnectionStrings["Lms"].ToString();
            SqlCommandTimeoutSeconds = GetIntValueFromWebConfig("Lms.Common.DB.SqlCommandTimeoutSeconds");
            IsEnableTraceLogging = GetBooleanValueFromWebConfig("Lms.Common.TraceLog.IsEnableTraceLogging");
            RequestKeyContextItemName = GetValueFromWebConfig("Lms.Common.TraceLog.RequestKeyContextItemName");
            EnableJsCssMinification = GetBooleanValueFromWebConfig("Lms.Site.UI.EnableJsCssMinification");
        }

        #region App settings methdos

        private static int GetIntValueFromWebConfig(string name)
        {
            string value = GetValueFromWebConfig(name);
            int result;
            int.TryParse(value, out result);
            return result;
        }

        private static double GetDoubleValueFromConfig(string name)
        {
            string value = GetValueFromWebConfig(name);
            double result;
            double.TryParse(value, NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"), out  result);
            return result;
        }

        private static long? GetLongValueFromWebConfig(string name)
        {
            string value = GetValueFromWebConfig(name);
            long result;
            if (long.TryParse(value, out result))
            {
                return result;
            }
            return null;
        }

        private static bool GetBooleanValueFromWebConfig(string name)
        {
            string value = GetValueFromWebConfig(name);
            bool result;
            bool.TryParse(value, out result);
            return result;
        }

        private static DateTime GetDateTimeValueFromWebConfig(string name)
        {
            string value = GetValueFromWebConfig(name);
            DateTime result;
            DateTime.TryParse(value, out result);
            return result;
        }

        private static string GetValueFromWebConfig(string name)
        {
            string value = System.Configuration.ConfigurationManager.AppSettings[name];
            if (string.IsNullOrWhiteSpace(value))
            {
                Logger.WarnFormat("Value '{0}' has not been found in config file'", name);
            }
            return value;
        }

        #endregion

        #region Custom sections methdos

        private static bool GetSection(string sectionName, out object section)
        {
            section = System.Configuration.ConfigurationManager.GetSection(sectionName);

            if (section != null)
            {
                return true;
            }

            Logger.WarnFormat("Section '{0}' has not been found in config file'", sectionName);

            return false;
        }

        #endregion

        #endregion
    }
}