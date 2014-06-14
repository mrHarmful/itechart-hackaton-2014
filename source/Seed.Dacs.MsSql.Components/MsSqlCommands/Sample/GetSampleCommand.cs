using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Seed.Dacs.MsSql.Components.MsSqlHelpers;
using Seed.Entities;

namespace Seed.Dacs.MsSql.Components.MsSqlCommands
{
    internal class GetSampleCommand : BaseCommand<Sample>
    {
        private Sample _result;

        public GetSampleCommand()
        {
            StoredProcedureName = string.Empty;
        }

        public override void CommandBody(SqlCommand cmd)
        {
            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = DBNull.Value;
            cmd.Parameters.Add("@TotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {

            }

        }

        protected override Sample GetCommandResult(SqlCommand cmd)
        {
            return _result;
        }
    }
}
