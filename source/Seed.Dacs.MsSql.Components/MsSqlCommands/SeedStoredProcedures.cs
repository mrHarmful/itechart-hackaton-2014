﻿namespace Seed.Dacs.MsSql.Components.MsSqlCommands
{
    public struct SeedStoredProcedures
    {
        #region Get stored procedures

        public const string GetAchievements = "sp_Common_GetAchievements";

        public const string GetCategories = "sp_Common_GetCategories";

        public const string GetPriorities = "sp_Common_GetPriorities";

        public const string GetDepartments = "sp_Common_GetDepartments";

        public const string SearchQuizzes = "sp_SearchSessions";

        public const string SearchQuizzesByCreator = "sp_SearchSessionsByCreator";

        public const string SearchSingleQuestions = "sp_SearchSingleQuestions";

        public const string SearchSingleQuestionsByCreator = "sp_SearchSingleQuestionsByCreator";

        public const string GetQuiz = "sp_GetSession";

        public const string GetQuestion = "sp_GetQuestion";

        public const string GetSingleQuestion = "sp_GetSingleQuestion";

        public const string GetQuestionOfTheDay = "sp_GetQuestionOfTheDay";

        public const string GetRandomQuestion = "sp_GetRandomSingleQuestion";

        #endregion

        #region Put stored procedures

        public const string SaveQuestion = "sp_InsertQuestion";

        public const string SaveQuiz = "sp_InsertSession";

        public const string SaveAnswer = "sp_SaveAnswer";

        #endregion

        #region Update stored procedures

        public const string DeactivateQuestion = "sp_DeactivateQuestion";

        public const string DeactivateQuiz = "sp_DeactivateSession";

        #endregion
    }
}