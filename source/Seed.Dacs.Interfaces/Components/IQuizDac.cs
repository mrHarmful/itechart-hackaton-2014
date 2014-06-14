using Seed.Entities;
using Seed.Entities.AccountItems;

namespace Seed.Dacs.Interfaces.Components
{
    public interface IQuizDac
    {
        UserQuizList GetQuizListForEdit(long userId);

        Quiz GetQuiz(long quizId);

        Question GetQuestion(long questionId);

        SingleQuestion GetSingleQuestion(long questionId);

        void SaveQuiz(Quiz quiz);

        void SaveQuestion(Question question);

        void SaveSingleQuestion(SingleQuestion question);
    }
}