using System.Collections.Generic;
using Seed.Dacs.Interfaces;
using Seed.Entities;
using Seed.Entities.AccountItems;
using Seed.Entities.Enums;

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

        public UserQuizList GetQuizList(long userId)
        {
            UserQuizList result = new UserQuizList();//_quizDac.GetQuizList(userId);
            result.Questions = new List<SingleQuestion>();
            for (int i = 0; i < 11; i++)
            {
                var q = new SingleQuestion();
                q.Enquiry = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer.";
                q.Id = i;
                q.Category = new Category {Title = "CatTitle"};
                q.Target = new List<Department>();
                q.Target.Add(new Department(){Name = "D1"});
                q.Priority = QuizPriority.Hight;
                result.Questions.Add(q);
            }
            result.Quizzes = new List<Quiz>();
            for (int i = 0; i < 11; i++)
            {
                var q = new Quiz();
                q.Title = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer.";
                q.Id = i;
                q.Category = new Category { Title = "CatTitle" };
                q.Target = new List<Department>();
                q.Target.Add(new Department() { Name = "D1" });
                q.Priority = QuizPriority.Hight;
                for (int j = 0; j < 11; j++)
                {
                    var qq = new SingleQuestion();
                    qq.Enquiry = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer.";
                    q.Questions.Add(qq);
                }
                result.Quizzes.Add(q);
            }
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

        public void SaveSingleQuestion(SingleQuestion question)
        {
            _quizDac.SaveSingleQuestion(question);
        }

        #endregion
    }
}