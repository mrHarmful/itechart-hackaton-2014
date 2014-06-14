using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Seed.Dacs.MsSql.Components.MsSqlHelpers;

namespace Seed.Dacs.MsSql.Components.MsSqlCommands.Common
{
    internal class GetQuizTypesCommand : BaseCommand<Dictionary<long, string>>
    {
        private Dictionary<long, string> _result;

        public GetQuizTypesCommand()
        {
            StoredProcedureName = SeedStoredProcedures.GetQuizTypes;
            _result = new Dictionary<long, string>();
        }

        public override void CommandBody(SqlCommand cmd)
        {
            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Tuple<long, string> entry = reader.GetDictionaryEntry();
                    _result.Add(entry.Item1, entry.Item2);
                }
            }

        }

        protected override Dictionary<long, string> GetCommandResult(SqlCommand cmd)
        {
            return _result;
        }
    }
}
