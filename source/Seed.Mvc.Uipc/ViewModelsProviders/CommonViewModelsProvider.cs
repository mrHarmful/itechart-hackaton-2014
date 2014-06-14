using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using Seed.Configuration;
using Seed.Localization;
using Seed.Utilities;
using Seed.Web.Uipc.ViewModels;

namespace Seed.Web.Uipc
{
    public static partial class ViewModelsProvider
    {
        #region Properties

        public static ConfigurationManager Config
        {
            get { return ConfigurationManager.Instance; }
        }

        #endregion

        #region Public methods

        public static ErrorVm GetErrorVm(string message, ErrorType type)
        {
            var vm = new ErrorVm();

            vm.ErrorMessage = message;
            vm.Type = type;

            return vm;
        }



        public static LocalizationVm GetLocalizationVm(CultureInfo culture)
        {
            var result = new LocalizationVm();

            result.ErrorMessages =
                GetLocalization(ErrorMessages.ResourceManager.GetResourceSet(culture, true, true));

            result.Enums =
                GetLocalization(Enums.ResourceManager.GetResourceSet(culture, true, true));

            return result;
        }

        #endregion

        #region Private methods

        private static Dictionary<string, string> GetLocalization(ResourceSet resourceSet)
        {
            var result = new Dictionary<string, string>();

            foreach (DictionaryEntry entry in resourceSet)
            {
                string key = entry.Key as string;
                string localizedString = entry.Value as string;

                if (key.IsNullOrEmpty() || localizedString.IsNullOrEmpty())
                {
                    continue;
                }

                result.Add(key, localizedString);
            }

            return result;
        }

        #endregion
    }
}