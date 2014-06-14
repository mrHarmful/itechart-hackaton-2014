using System;
using Seed.Entities;
using Seed.Entities.AccountItems;

namespace Seed.Bcs
{
    internal class QuizBc
    {
        #region Private fields

        //private readonly IQuizDac _quizDac;

        #endregion

        #region Singleton

        private static QuizBc _quizBc;

        private static readonly object Locker;

        static QuizBc()
        {
            Locker = new object();
        }

        private QuizBc()
        {
            //_quizDac = DacFactoryClient.GetConcreteFactory().GetSampleDac();
        }

        public static QuizBc Instance
        {
            get
            {
                if (_quizBc == null)
                {
                    lock (Locker)
                    {
                        if (_quizBc == null)
                        {
                            _quizBc = new QuizBc();
                        }
                    }
                }

                return _quizBc;
            }
        }

        #endregion

        #region Public methods

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
            throw new NotImplementedException();
        }

        public void SaveQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public void SaveSingleQuestion(SingleQuestion question)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}