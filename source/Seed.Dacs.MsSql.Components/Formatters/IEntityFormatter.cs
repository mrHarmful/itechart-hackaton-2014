namespace Seed.Dacs.MsSql.Components.Formatters
{
    internal interface IEntityFormatter<in TEntity>
    {
        #region Public methods

        void Apply(TEntity entity);

        #endregion
    }
}