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
    internal class SaveQuestionCommand : BaseCommand<bool>
    {
        private Question _question;
        private int _sequence;

        public SaveQuestionCommand(Question question, int sequence)
        {
            StoredProcedureName = SeedStoredProcedures.SaveQuestion;
            _question = question;
            _sequence = sequence;
        }

        public override void CommandBody(SqlCommand cmd)
        {
            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Title", SqlDbType.VarChar, 300).Value = _question.Enquiry;
            cmd.Parameters.Add("@Reason", SqlDbType.VarChar, 300).Value = DBNull.Value;
            cmd.Parameters.Add("@SessionId", SqlDbType.BigInt).Value = _question.QuizId;
            cmd.Parameters.Add("@SessionSequence", SqlDbType.Int).Value = _sequence;
            cmd.Parameters.Add("@CreatorId", SqlDbType.BigInt).Value = _question.OwnerId;
            cmd.Parameters.Add("@IsSingleSelect", SqlDbType.Bit).Value = _question.IsSingleSelect;
            cmd.Parameters.Add("@IsSkippable", SqlDbType.Bit).Value = _question.CanSkip;
            cmd.Parameters.Add("@CreateTime", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = DBNull.Value;
            cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = DBNull.Value;
            cmd.Parameters.Add("@PriorityId", SqlDbType.BigInt).Value = DBNull.Value;
            cmd.Parameters.Add("@CategoryId", SqlDbType.BigInt).Value = DBNull.Value;

            /*cmd.Parameters.Add("@CreateCost", SqlDbType.Int).Value = DBNull.Value;
            cmd.Parameters.Add("@ReturnPoints", SqlDbType.Int).Value = DBNull.Value;*/

            cmd.Parameters.Add("@Answers", SqlDbType.Structured).Value = _question.Answers.ToAnswerVariantsTable();
            cmd.Parameters.Add("@AllowedDepts", SqlDbType.Structured).Value = (new List<int>()).ToIdsList();

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
