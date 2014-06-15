using System;
using System.Data.SqlClient;
using Seed.Entities;
using System.Collections;
using System.Collections.Generic;

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

        public static SingleQuestion GetSearchSingleQuestion(this SqlDataReader reader)
        {
            SingleQuestion result = new SingleQuestion();
            //Id, Title, IsSingleSelect, IsSkippable, CreatorId, StartTime, EndTime, PriorityId, CategoryId, CreateCost

            result.Id = reader.GetValue<long>("Id");
            result.Enquiry = reader.GetValue<string>("Title");
            result.CategoryId = reader.GetValue<long>("CategoryId");
            result.PriorityId = reader.GetValue<long>("PriorityId");
            result.StartDate = reader.GetValue<DateTime>("StartTime");
            result.EndDate = reader.GetValue<DateTime>("EndTime");
            result.CanSkip = reader.GetValue<bool>("IsSkippable");
            result.IsSingleSelect = reader.GetValue<bool>("IsSingleSelect");

            return result;
        }

        public static Quiz GetSearchQuiz(this SqlDataReader reader)
        {
            Quiz result = new Quiz();
            //Id, Title, Reason, CategoryId, PriorityId, CreateDate, StartTime, EndTime, CreateCost, QuestionsCount

            result.Id = reader.GetValue<long>("Id");
            result.Title = reader.GetValue<string>("Title");
            result.Reason = reader.GetValue<string>("Reason");
            result.CategoryId = reader.GetValue<long>("CategoryId");
            result.PriorityId = reader.GetValue<long>("PriorityId");
            result.StartDate = reader.GetValue<DateTime>("StartTime");
            result.EndDate = reader.GetValue<DateTime>("EndTime");

            int questionsCount = reader.GetValue<int>("QuestionsCount");
            result.Questions = new List<Question>(new Question[questionsCount]);

            return result;
        }

        public static Question GetQuestion(this SqlDataReader reader)
        {
            Question result = new Question();

            result.Id = reader.GetValue<long>("Id");
            result.Enquiry = reader.GetValue<string>("Title");
            result.CanSkip = reader.GetValue<bool>("IsSkippable");
            result.IsSingleSelect = reader.GetValue<bool>("IsSingleSelect");

            return result;
        }

        public static Answer GetAnswer(this SqlDataReader reader)
        {
            Answer result = new Answer();

            result.Id = reader.GetValue<long>("Id");
            result.QuestionId = reader.GetValue<long>("QuestionId");
            result.Caption = reader.GetValue<string>("Text");

            return result;
        }

        public static Tuple<long, long> GetRestrictionEntry(this SqlDataReader reader)
        {
            long itemId = reader.GetValue<long>("ItemId");
            long deptId = (long)reader.GetValue<int>("DeptId");

            return new Tuple<long, long>(itemId, deptId);
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
