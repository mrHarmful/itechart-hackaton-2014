using System;
using Seed.Dacs.Interfaces.Components;
using Seed.Entities;
using Seed.Entities.AccountItems;

namespace Seed.Dacs.MsSql.Components.MsSqlComponents
{
    public class MsSqlQuizDac : IQuizDac
    {
        #region IQuizDac Members

        public UserQuizList GetQuizListForEdit(long userId)
        {
            throw new NotImplementedException();
        }

        public Quiz GetQuiz(long quizId)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestion(long questionId)
        {
            throw new NotImplementedException();
        }

        public SingleQuestion GetSingleQuestion(long questionId)
        {
            throw new NotImplementedException();
        }

        public void SaveQuiz(Quiz quiz)
        {
            //NOTE: save/update, seems only generic quiz items, questions will be saved separately
            throw new NotImplementedException();
        }

        public void SaveQuestion(Question question)
        {
            //NOTE: save/update
            throw new NotImplementedException();
        }

        public void SaveSingleQuestion(SingleQuestion question)
        {
            //NOTE: save/update
            throw new NotImplementedException();
        }

        #endregion
    }
}