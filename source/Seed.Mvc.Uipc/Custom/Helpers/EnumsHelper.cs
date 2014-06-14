using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Seed.Localization;
using Seed.Web.Uipc.ViewModels;

namespace Seed.Web.Uipc
{
    public static class EnumsHelper
    {
        #region Public methods

        public static IEnumerable<T> FromEnumToList<T>(IEnumerable<T> excludedEnums) where T : struct
        {
            if (!typeof (T).IsEnum)
            {
                throw new ArgumentException(ErrorMessages.NotEnumType);
            }

            IEnumerable<T> enumValues = Enum.GetValues(typeof (T)).Cast<T>();

            if (excludedEnums != null)
            {
                enumValues = enumValues.Except(excludedEnums);
            }

            return enumValues;
        }

        public static string Name<T>(this T enumType) where T : struct
        {
            if (!typeof (T).IsEnum)
            {
                throw new ArgumentException(ErrorMessages.NotEnumType);
            }

            return Enum.GetName(typeof (T), enumType);
        }

        public static string Name<T>(this T? enumType) where T : struct
        {
            if (enumType == null)
            {
                return string.Empty;
            }

            return ((T) enumType).Name();
        }

        public static List<CheckBoxVm> ToCheckBoxViewModelList<T>(
            IEnumerable<T> selectedEnums,
            IEnumerable<T> excludedEnums = null) where T : struct
        {
            if (!typeof (T).IsEnum)
            {
                throw new ArgumentException(ErrorMessages.NotEnumType);
            }

            List<CheckBoxVm> result = FromEnumToList(excludedEnums).Select(
                v => new CheckBoxVm
                     {
                         IsChecked = selectedEnums != null && selectedEnums.Contains(v),
                         Text = v.GetEnumLocalizedValue() ?? v.ToString(),
                         Value = Convert.ToInt32(v).ToString(CultureInfo.InvariantCulture)
                     }).ToList();

            return result;
        }

        public static List<SelectListItem> ToRedefineSelectList<TSortType>(
            TSortType selectedMember,
            Func<TSortType, string> getRedefineName,
            IEnumerable<TSortType> excludedEnums = null) where TSortType : struct, IConvertible
        {
            if (!typeof (TSortType).IsEnum)
            {
                throw new ArgumentException(ErrorMessages.NotEnumType);
            }

            List<SelectListItem> result = FromEnumToList(excludedEnums).Select(
                v =>
                {
                    var item = new SelectListItem();

                    item.Text = v.GetEnumLocalizedValue() ?? v.ToString();
                    item.Value = getRedefineName(v);
                    item.Selected = v.Equals(selectedMember);

                    return item;
                }).ToList();

            return result;
        }

        public static List<SelectListItem> ToSelectList<T>(T selectedMember, IEnumerable<T> excludedEnums = null)
            where T : struct
        {
            if (!typeof (T).IsEnum)
            {
                throw new ArgumentException(ErrorMessages.NotEnumType);
            }

            List<SelectListItem> result = FromEnumToList(excludedEnums).Select(
                v => new SelectListItem
                     {
                         Text = v.GetEnumLocalizedValue() ?? v.ToString(),
                         Value = Convert.ToInt32(v).ToString(CultureInfo.InvariantCulture),
                         Selected = v.Equals(selectedMember)
                     }).ToList();

            return result;
        }

        #endregion
    }
}