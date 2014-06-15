using System;
using System.Collections.Generic;
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

            var command2 = new SearchSingleQuestionsByUserIdCommand(userId);

            command2.Execute();

            list.Questions = command2.CommandResult;

            return list;
        }

        public Quiz GetQuiz(long quizId)
        {
            var command = new GetQuizCommand(quizId);

            command.Execute();

            return command.CommandResult;
        }

        public Question GetQuestion(long questionId)
        {
            var command = new GetQuestionCommand(questionId);

            command.Execute();

            return command.CommandResult;
        }

        public SingleQuestion GetSingleQuestion(long questionId)
        {
            var command = new GetSingleQuestionCommand(questionId);

            command.Execute();

            return command.CommandResult;
        }

        public void SaveAnswer(long questionId, long answerId, long userId)
        {
            var command = new SaveAnswerCommand(questionId, answerId, userId);
            command.Execute();
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