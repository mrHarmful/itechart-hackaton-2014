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
    internal class GetQuizCommand:BaseCommand<Entities.Quiz>
    {
        private Entities.Quiz _result;
        private long _quizId;

        public GetQuizCommand(long quizId)
        {
            StoredProcedureName = SeedStoredProcedures.GetQuiz;
            _quizId = quizId;
            _result = new Entities.Quiz();
        }

        public override void CommandBody(SqlCommand cmd)
        {
            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SessionId", SqlDbType.BigInt).Value = _quizId;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    _result = reader.GetSearchQuiz();
                }

                reader.NextResult();

                _result.Questions = new List<Question>();
                while (reader.Read())
                {
                    Question question = reader.GetQuestion();
                    _result.Questions.Add(question);
                }

                reader.NextResult();

                List<Answer> answers = new List<Answer>();
                while (reader.Read())
                {
                    Answer answer = reader.GetAnswer();
                    answers.Add(answer);
                }

                _result.Questions.ForEach(q => q.Answers = answers.Where(a => a.QuestionId == q.Id).ToList());

                reader.NextResult();
                List<Tuple<long, long>> restrictions = new List<Tuple<long, long>>();
                while (reader.Read())
                {
                    Tuple<long, long> item = reader.GetRestrictionEntry();
                    restrictions.Add(item);
                }

                _result.Targets = restrictions.Where(t => t.Item1 == _result.Id).Select(t => t.Item2).ToList();
            }

        }

        protected override Entities.Quiz GetCommandResult(SqlCommand cmd)
        {
            return _result;
        }
    }
}
