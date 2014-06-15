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
    internal class GetQuestionCommand : BaseCommand<Question>
    {
        private Question _result;
        private long _questionId;

        public GetQuestionCommand(long questionId)
        {
            StoredProcedureName = SeedStoredProcedures.GetQuestion;
            _questionId = questionId;
            _result = new Question();
        }

        public override void CommandBody(SqlCommand cmd)
        {
            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@QuestionId", SqlDbType.BigInt).Value = _questionId;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    _result = reader.GetQuestion();
                }
                reader.NextResult();

                while (reader.Read())
                {
                    Answer answer = reader.GetAnswer();
                    _result.Answers.Add(answer);
                }
            }

        }

        protected override Question GetCommandResult(SqlCommand cmd)
        {
            return _result;
        }
    }
}
