using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Seed.Dacs.MsSql.Components.MsSqlCommands.Quiz
{
    internal class DeactivateQuizCommand : BaseCommand<bool>
    {
        private long _id;

        public DeactivateQuizCommand(long id)
        {
            StoredProcedureName = SeedStoredProcedures.DeactivateQuiz;
            _id = id;
        }

        public override void CommandBody(SqlCommand cmd)
        {
            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SessionId", SqlDbType.BigInt).Value = _id;

            cmd.ExecuteNonQuery();
        }

        protected override bool GetCommandResult(SqlCommand cmd)
        {
            return true;
        }

    }
}
