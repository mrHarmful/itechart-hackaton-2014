using System;
using Seed.Dacs.Interfaces;
using Seed.Entities;
using Seed.Entities.AccountItems;
using Seed.Dacs.MsSql.Components.MsSqlCommands.Quiz;

namespace Seed.Dacs.MsSql.Components.MsSqlComponents
{
    public class MsSqlQuizDac : IQuizDac
    {
        #region IQuizDac Members

        public QuizList GetAvailableQuizes(long userId)
        {
            var command = new SearchAvailableQuizesCommand(userId);

            command.Execute();

            return command.CommandResult;
        }

        public UserQuizList GetUserQuizList(long userId)
        {
            var command = new SearchQuizesByUserIdCommand(userId);

            command.Execute();

            UserQuizList list = new UserQuizList();
            list.Quizzes = command.CommandResult.Quizzes;

            return list;
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
            var command = new SaveQuizCommand(quiz);
            command.Execute();

            int counter = 1;
            foreach (Question q in quiz.Questions)
            {
                q.QuizId = quiz.Id;
                var questionCommand = new SaveQuestionCommand(q, counter);
                questionCommand.Execute();
                counter++;
            }

        }

        public void SaveSingleQuestion(SingleQuestion question)
        {
            var command = new SaveSingleQuestionCommand(question);
            command.Execute();
        }

        public void DeactivateQuiz(long quizId)
        {
            var command = new DeactivateQuizCommand(quizId);
            command.Execute();
        }

        public void DeactivateQuestion(long questionId)
        {
            var command = new DeactivateQuestionCommand(questionId);
            command.Execute();
        }

        #endregion
    }
}