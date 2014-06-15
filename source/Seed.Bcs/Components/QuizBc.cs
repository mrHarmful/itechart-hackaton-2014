using System;
using System.Collections.Generic;
using Seed.Dacs.Interfaces;
using Seed.Entities;
using Seed.Entities.AccountItems;

namespace Seed.Bcs
{
    public class QuizBc
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

        public QuizList GetQuizListForAttend(long userId)
        {
            var result = _quizDac.GetAvailableQuizes(userId);

            return result;
        }

        public UserQuizList GetQuizList(long userId)
        {
            var result = _quizDac.GetUserQuizList(userId);
            
            return result;
        }

        public Quiz GetQuiz(long quizId)
        {
            Quiz result = _quizDac.GetQuiz(quizId);

            return result;
        }

        public Question GetQuestion(long questionId)
        {
            /*Question result = _quizDac.GetQuestion(questionId);

            return result;*/

            var qq = new Question();
            qq.Id = 1;
            qq.CanSkip = false;
            qq.IsUserMeta = false;
            qq.QuizId = 2;
            qq.Enquiry = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer.";

            var a1 = new Answer();
            a1.Caption = "Yes";
            a1.Id = 13;
            a1.QuestionId = 2;

            var a2 = new Answer();
            a2.Caption = "No";
            a2.Id = 14;
            a2.QuestionId = 2;
            qq.Answers.Add(a1);
            qq.Answers.Add(a2);

            return qq;
        }

        public SingleQuestion GetRamdomSingleQuestionForUser(long userId)
        {
            throw new NotImplementedException();
        }

        public SingleQuestion GetSingleQuestion(long questionId)
        {
            SingleQuestion result = _quizDac.GetSingleQuestion(questionId);

            return result;
        }

        public void SaveAnswer(long questionId, long answerId, int userId)
        {
            throw new NotImplementedException();
        }

        public void SaveQuiz(Quiz quiz)
        {
            _quizDac.SaveQuiz(quiz);
        }

        public void SaveSingleQuestion(SingleQuestion question)
        {
            _quizDac.SaveSingleQuestion(question);
        }

        #endregion
    }
}