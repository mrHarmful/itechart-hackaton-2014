namespace Seed.Dacs.MsSql.Components.MsSqlCommands
{
    public struct SeedStoredProcedures
    {
        #region Get stored procedures

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