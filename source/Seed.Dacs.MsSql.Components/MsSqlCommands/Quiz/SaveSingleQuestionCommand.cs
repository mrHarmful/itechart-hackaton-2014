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
    internal class SaveSingleQuestionCommand:BaseCommand<bool>
    {
        private SingleQuestion _question;

        public SaveSingleQuestionCommand(SingleQuestion question)
        {
            StoredProcedureName = SeedStoredProcedures.SaveQuestion;
            _question = question;
        }

        public override void CommandBody(SqlCommand cmd)
        {
            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Title", SqlDbType.VarChar, 300).Value = _question.Enquiry;
            cmd.Parameters.Add("@SessionId", SqlDbType.BigInt).Value = DBNull.Value;
            cmd.Parameters.Add("@SessionSequence", SqlDbType.Int).Value = DBNull.Value;
            cmd.Parameters.Add("@CreatorId", SqlDbType.BigInt).Value = _question.OwnerId;
            cmd.Parameters.Add("@IsSingleSelect", SqlDbType.Bit).Value = _question.IsSingleSelect;
            cmd.Parameters.Add("@IsSkippable", SqlDbType.Bit).Value = _question.CanSkip;
            cmd.Parameters.Add("@CreateTime", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = _question.StartDate;
            cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = _question.EndDate;
            cmd.Parameters.Add("@PriorityId", SqlDbType.BigInt).Value = _question.PriorityId;
            cmd.Parameters.Add("@CategoryId", SqlDbType.BigInt).Value = _question.CategoryId;

            /*cmd.Parameters.Add("@CreateCost", SqlDbType.Int).Value = DBNull.Value;
            cmd.Parameters.Add("@ReturnPoints", SqlDbType.Int).Value = DBNull.Value;*/

            cmd.Parameters.Add("@Answers", SqlDbType.Structured).Value = _question.Answers.ToAnswerVariantsTable();
            cmd.Parameters.Add("@AllowedDepts", SqlDbType.Structured).Value = _question.Targets.Select(x => (int) x).ToIdsList();

            cmd.Parameters.Add("@QuestionId", SqlDbType.BigInt).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
        }

        protected override bool GetCommandResult(SqlCommand cmd)
        {
            _question.Id = (long)cmd.Parameters["@QuestionId"].Value;

            return true;
        }
    }
}
