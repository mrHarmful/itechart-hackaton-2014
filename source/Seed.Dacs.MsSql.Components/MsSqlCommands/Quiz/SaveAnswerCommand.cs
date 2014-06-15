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
    internal class SaveAnswerCommand : BaseCommand<bool>
    {
        private long _questionId;
        private long _answerId;
        private long _userId;

        public SaveAnswerCommand(long questionId, long answerId, long userId)
        {
            StoredProcedureName = SeedStoredProcedures.SaveAnswer;
            _questionId = questionId;
            _answerId = answerId;
            _userId = userId;
        }

        public override void CommandBody(SqlCommand cmd)
        {
            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@QuestionId", SqlDbType.BigInt).Value = _questionId;
            cmd.Parameters.Add("@AnswerId", SqlDbType.BigInt).Value = _answerId;
            cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = _userId;

            cmd.ExecuteNonQuery();
        }

        protected override bool GetCommandResult(SqlCommand cmd)
        {
            return true;
        }
    }
}
