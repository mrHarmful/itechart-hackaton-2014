namespace Seed.Dacs.MsSql.Components.MsSqlCommands
{
    public struct SeedStoredProcedures
    {
        #region Get stored procedures

        public const string GetAchievements = "sp_Common_GetAchievements";

        public const string GetCategories = "sp_Common_GetCategories";

        public const string GetPriorities = "sp_Common_GetPriorities";

        public const string GetDepartments = "sp_Common_GetDepartments";

        #endregion

        #region Put stored procedures

        public const string SaveQuestion = "sp_InsertQuestion";

        public const string SaveQuiz = "sp_InsertSession";

        #endregion

        #region Update stored procedures

        public const string DeactivateQuestion = "sp_DeactivateQuestion";

        public const string DeactivateQuiz = "sp_DeactivateSession";

        #endregion
    }
}