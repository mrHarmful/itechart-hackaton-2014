using Seed.Dacs.Interfaces.Components;
using Seed.Entities;
using Seed.Entities.AccountItems;

namespace Seed.Bcs
{
    internal class QuizBc
    {
        #region Private fields

        private readonly IQuizDac _quizDac;

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
            _quizDac = DacFactoryClient.GetConcreteFactory().GetQuizDac();
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
            UserQuizList result = _quizDac.GetQuizListForEdit(userId);

            return result;
        }

        public Quiz GetQuiz(long quizId)
        {
            Quiz result = _quizDac.GetQuiz(quizId);

            return result;
        }

        public Question GetQuestion(long questionId)
        {
            Question result = _quizDac.GetQuestion(questionId);

            return result;
        }

        public SingleQuestion GetSingleQuestion(long questionId)
        {
            SingleQuestion result = _quizDac.GetSingleQuestion(questionId);

            return result;
        }

        public void SaveQuiz(Quiz quiz)
        {
            _quizDac.SaveQuiz(quiz);
        }

        public void SaveQuestion(Question question)
        {
            _quizDac.SaveQuestion(question);
        }

        public void SaveSingleQuestion(SingleQuestion question)
        {
            _quizDac.SaveSingleQuestion(question);
        }

        #endregion
    }
}