using System;
using System.Collections.Generic;
using System.Data;

namespace Seed.Dacs.MsSql.Components.MsSqlHelpers
{
    public static class ParameterHelper
    {
        public static object ValueOrDBNull<T>(this T value)
        {
            object result = value == null
                ? DBNull.Value
                : (object)value;

            return result;
        }

        public static T GetNullableDbValue<T>(this object obj)
        {
            return obj == null || obj == DBNull.Value ? default(T) : (T)obj;
        }

        public static DataTable ToBookNumberTable(this IEnumerable<string> list)
        {
            DataTable dataTable = new DataTable("BookNumbers");

            dataTable.Columns.Add(GetDataColumn<string>("BookNumber", false));

            foreach (var item in list ?? new List<string>())
            {
                dataTable.Rows.Add(item);
            }

            return dataTable;
        }

        public static DataTable ToIdListTable(this IEnumerable<long> list)
        {
            DataTable dataTable = new DataTable("IdsList");

            dataTable.Columns.Add(GetDataColumn<long>("ObjectId", false));


            foreach (var item in list ?? new List<long>())
            {
                dataTable.Rows.Add(item);
            }

            return dataTable;
        }

        private static DataColumn GetDataColumn<T>(string columnName, bool allowDbNull, int? size = null)
        {
            DataColumn result = new DataColumn(columnName);
            result.DataType = typeof(T);
            if (size.HasValue)
            {
                result.MaxLength = size.Value;
            }
            result.AllowDBNull = allowDbNull;
            if (allowDbNull)
            {
                result.DefaultValue = null;
            }

            return result;
        }
    }
}
