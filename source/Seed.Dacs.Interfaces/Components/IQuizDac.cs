using Seed.Entities;
using Seed.Entities.AccountItems;

namespace Seed.Dacs.Interfaces
{
    public interface IQuizDac
    {
        QuizList GetAvailableQuizes(long userId);

        UserQuizList GetUserQuizList(long userId);

        Quiz GetQuiz(long quizId);

        Question GetQuestion(long questionId);

        SingleQuestion GetSingleQuestion(long questionId);

        void SaveQuiz(Quiz quiz);

        void SaveSingleQuestion(SingleQuestion question);
    }
}