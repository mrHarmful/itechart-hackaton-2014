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
    internal class GetSingleQuestionCommand : BaseCommand<SingleQuestion>
    {
        private SingleQuestion _result;
        private long _quizId;

        public GetSingleQuestionCommand(long quizId)
        {
            StoredProcedureName = SeedStoredProcedures.GetSingleQuestion;
            _quizId = quizId;
            _result = new SingleQuestion();
        }

        public override void CommandBody(SqlCommand cmd)
        {
            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@QuestionId", SqlDbType.BigInt).Value = _quizId;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    _result = reader.GetSearchSingleQuestion();
                }
                reader.NextResult();

                while (reader.Read())
                {
                    Answer answer = reader.GetAnswer();
                    _result.Answers.Add(answer);
                }
                
                reader.NextResult();
                List<Tuple<long, long>> restrictions = new List<Tuple<long, long>>();
                while (reader.Read())
                {
                    Tuple<long, long> item = reader.GetRestrictionEntry();
                    restrictions.Add(item);
                }

                _result.Targets = restrictions.Where(t => t.Item1 == _result.Id).Select(t => t.Item2).ToList();
            }

        }

        protected override SingleQuestion GetCommandResult(SqlCommand cmd)
        {
            return _result;
        }
    }
}
