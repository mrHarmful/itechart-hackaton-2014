using System;
using System.Linq;
using Seed.Logging;

namespace Seed.Localization
{
    public static class LocalizationExtensions
    {
        /// <summary>
        /// Gets enum localized value from resources
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <param name="enumValue">Enum value</param>
        /// <returns>Enum localized value</returns>
        public static string GetEnumLocalizedValue<T>(this T enumValue) where T : struct
        {
            if (!typeof (T).IsEnum)
            {
                throw new ArgumentException(ErrorMessages.NotEnumType);
            }

            string enumLocalizedKey = string.Format("{0}_{1}_{2}",
                                                    "Enm",
                                                    enumValue.GetType().ToString().Split('.').Last(),
                                                    enumValue);

            string result = null;

            try
            {
                result = Enums.ResourceManager.GetString(enumLocalizedKey);
            }
            catch (Exception e)
            {
                Logger.ErrorFormat("Exception during retrieving '{0}' key value from resources.", e, enumLocalizedKey);
            }

            return result ?? enumValue.ToString();
        }

        public static string GetEnumLocalizedValue<T>(this T? enumValue) where T : struct
        {
            if (enumValue == null)
            {
                return string.Empty;
            }

            return ((T) enumValue).GetEnumLocalizedValue();
        }
    }
}