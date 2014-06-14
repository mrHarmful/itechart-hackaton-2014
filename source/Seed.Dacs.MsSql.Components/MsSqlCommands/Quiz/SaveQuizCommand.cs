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
            cmd.Parameters.Add("@PriorityId", SqlDbType.BigInt).Value = (long)_quiz.Priority;
            cmd.Parameters.Add("@CategoryId", SqlDbType.BigInt).Value = _quiz.Category.Id;
            cmd.Parameters.Add("@CreateTime", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = _quiz.StartDate;
            cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = _quiz.EndDate;

            /*cmd.Parameters.Add("@CreateCost", SqlDbType.Int).Value = DBNull.Value;
            cmd.Parameters.Add("@ReturnPoints", SqlDbType.Int).Value = DBNull.Value;*/

            cmd.Parameters.Add("@AllowedDepts", SqlDbType.Structured).Value = _quiz.Target.Select(x => x.Id).ToIdsList();

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
