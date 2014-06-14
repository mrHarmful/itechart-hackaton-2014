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
    internal class SaveQuizCommand : BaseCommand<bool>
    {
        private Entities.Quiz _quiz;

        public SaveQuizCommand(Entities.Quiz quiz)
        {
            StoredProcedureName = SeedStoredProcedures.SaveQuiz;
            _quiz = quiz;
        }

        public override void CommandBody(SqlCommand cmd)
        {
            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CreatorId", SqlDbType.BigInt).Value = _quiz.OwnerId;
            cmd.Parameters.Add("@Title", SqlDbType.VarChar, 300).Value = _quiz.Title;
            cmd.Parameters.Add("@Reason", SqlDbType.VarChar, 300).Value = _quiz.Reason;
            cmd.Parameters.Add("@PriorityId", SqlDbType.BigInt).Value = _quiz.PriorityId;
            cmd.Parameters.Add("@CategoryId", SqlDbType.BigInt).Value = _quiz.CategoryId;
            cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = _quiz.StartDate;
            cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = _quiz.EndDate;

            cmd.Parameters.Add("@CreateCost", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@ReturnPoints", SqlDbType.Int).Value = 0;

            cmd.Parameters.Add("@AllowedDepts", SqlDbType.Structured).Value = _quiz.Targets.Select(t => (int) t).ToIdsList();

            cmd.Parameters.Add("@SessionId", SqlDbType.BigInt).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
        }

        protected override bool GetCommandResult(SqlCommand cmd)
        {
            _quiz.Id = (long)cmd.Parameters["@SessionId"].Value;

            return true;
        }
    }
}
