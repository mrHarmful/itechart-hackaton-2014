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

        void SaveAnswer(long questionId, long answerId, long userId);

        void SaveQuiz(Quiz quiz);

        void SaveSingleQuestion(SingleQuestion question);

        void DeactivateQuiz(long quizId);

        void DeactivateQuestion(long questionId);
    }
}