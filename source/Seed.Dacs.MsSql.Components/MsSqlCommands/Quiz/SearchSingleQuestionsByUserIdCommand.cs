using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Seed.Dacs.MsSql.Components.MsSqlHelpers;
using Seed.Entities;

namespace Seed.Dacs.MsSql.Components.MsSqlCommands.Quiz
{
    internal class SearchSingleQuestionsByUserIdCommand : BaseCommand<List<SingleQuestion>>
    {
        private List<SingleQuestion> _result;
        private long _userId;

        public SearchSingleQuestionsByUserIdCommand(long userId)
        {
            StoredProcedureName = SeedStoredProcedures.SearchSingleQuestionsByCreator;
            _userId = userId;
            _result = new List<SingleQuestion>();
        }

        public override void CommandBody(SqlCommand cmd)
        {
            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CreatorId", SqlDbType.BigInt).Value = _userId;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    SingleQuestion item = reader.GetSearchSingleQuestion();
                    _result.Add(item);
                }

                reader.NextResult();
                List<Tuple<long, long>> restrictions = new List<Tuple<long, long>>();
                while (reader.Read())
                {
                    Tuple<long, long> item = reader.GetRestrictionEntry();
                    restrictions.Add(item);
                }

                _result.ForEach(q => q.Targets = restrictions.Where(t => t.Item1 == q.Id).Select(t => t.Item2).ToList());
            }

        }

        protected override List<SingleQuestion> GetCommandResult(SqlCommand cmd)
        {
            return _result;
        }
    }
}
