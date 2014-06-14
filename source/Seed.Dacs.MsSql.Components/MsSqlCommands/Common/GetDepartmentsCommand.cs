using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Seed.Dacs.MsSql.Components.MsSqlHelpers;
using Seed.Entities;

namespace Seed.Dacs.MsSql.Components.MsSqlCommands.Common
{
    internal class GetDepartmentsCommand : BaseCommand<List<KeyValueItem>>
    {
        private List<KeyValueItem> _result;

        public GetDepartmentsCommand()
        {
            StoredProcedureName = SeedStoredProcedures.GetDepartments;
            _result = new List<KeyValueItem>();
        }

        public override void CommandBody(SqlCommand cmd)
        {
            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    KeyValueItem entry = reader.GetDictionaryEntry();
                    _result.Add(entry);
                }
            }

        }

        protected override List<KeyValueItem> GetCommandResult(SqlCommand cmd)
        {
            return _result;
        }
    }
}
