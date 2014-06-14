using System;
using System.Data.SqlClient;
using Seed.Entities;

namespace Seed.Dacs.MsSql.Components.MsSqlHelpers
{
    public static partial class DataReaderHelper
    {
        #region Public methods

        public static KeyValueItem GetDictionaryEntry(this SqlDataReader reader)
        {
            long key = reader.GetValue<long>("Id");
            string value = reader.GetValue<string>("Title");

            return new KeyValueItem{Id = key, Caption = value};
        }





        public static T GetValue<T>(this SqlDataReader dataReader, string columnName)
        {
            return (T)dataReader[columnName];
        }

        public static T GetNullableValue<T>(this SqlDataReader dataReader, string columnName)
        {
            T result = dataReader.HasValue(columnName)
                ? GetValue<T>(dataReader, columnName)
                : default(T);

            return result;
        }

        #endregion

        #region Private methods

        private static T GetEnumValue<T>(this SqlDataReader reader, string columnName, T defaultValue)
            where T : struct
        {
            Type type = typeof(T);

            if (reader.HasValue(columnName))
            {
                //Cast to int is necessary for Enum.Defined, because all enums are int-based
                //You cann't use direct int extracting, because it will fail with unboxing error
                var value = (int)reader.GetValue<short>(columnName);
                if (Enum.IsDefined(type, value))
                {
                    return (T)Enum.ToObject(type, value);
                }
            }
            return defaultValue;
        }

        private static bool HasValue(this SqlDataReader reader, string columnName)
        {
            try
            {
                int columnOrdinal = reader.GetOrdinal(columnName);
                return ((columnOrdinal >= 0) && !reader.IsDBNull(columnOrdinal));
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        #endregion
    }
}
