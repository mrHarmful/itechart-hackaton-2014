﻿using System;
using Seed.Dacs.Interfaces;
using Seed.Entities;
using Seed.Entities.AccountItems;
using Seed.Dacs.MsSql.Components.MsSqlCommands.Quiz;

namespace Seed.Dacs.MsSql.Components.MsSqlComponents
{
    public class MsSqlQuizDac : IQuizDac
    {
        #region IQuizDac Members

        public UserQuizList GetQuizList(long userId)
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
            var command = new SaveQuizCommand(quiz);
            command.Execute();

            int counter = 1;
            foreach (Question q in quiz.Questions)
            {
                q.QuizId = quiz.Id;
                var questionCommand = new SaveQuestionCommand(q, counter);
                command.Execute();
                counter++;
            }

        }

        public void SaveSingleQuestion(SingleQuestion question)
        {
            //NOTE: save/update
            throw new NotImplementedException();
        }

        #endregion
    }
}