using System;
using System.Collections.Generic;
using System.Data;
using Seed.Entities;

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

        public static DataTable ToAnswerVariantsTable(this IEnumerable<Answer> list)
        {
            DataTable dataTable = new DataTable("AnswerVariants");

            dataTable.Columns.Add(GetDataColumn<long>("QuestionId", true));
            dataTable.Columns.Add(GetDataColumn<string>("Text", false, 300));
            dataTable.Columns.Add(GetDataColumn<int>("Sequence", true));

            int counter = 1;
            foreach (var item in list ?? new List<Answer>())
            {
                dataTable.Rows.Add(item.QuestionId, item.Caption, counter);
                counter++;
            }

            return dataTable;
        }

        public static DataTable ToIdsList(this IEnumerable<int> list)
        {
            DataTable dataTable = new DataTable("IdsList");

            dataTable.Columns.Add(GetDataColumn<int>("Id", false));

            int counter = 1;
            foreach (var item in list ?? new List<int>())
            {
                dataTable.Rows.Add(item);
                counter++;
            }

            return dataTable;
        }

        private static DataColumn GetDataColumn<T>(string columnName, bool allowDbNull, int? size = null)
        {
            DataColumn result = new DataColumn(columnName);
            result.DataType = typeof(T);

            if (typeof(T).Equals(typeof(string)))
            {
                size = 300;
            }
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
