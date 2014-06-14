using System;
using System.Collections.Generic;
using Seed.Entities;

namespace Seed.Dacs.MsSql.Components.Formatters
{
    internal static class FormatterResolver
    {
        #region Static Fields

        private static readonly Dictionary<Type, object> Formatters = new Dictionary<Type, object>();

        #endregion

        #region Constructors

        static FormatterResolver()
        {
        }

        #endregion

        #region Public methods

        public static TEntity ApplyFormatting<TEntity>(this TEntity entity)
        {
            if (entity != null)
            {
                IEntityFormatter<TEntity> formatter = ResolveFormatter(entity);
                if (formatter != null)
                {
                    formatter.Apply(entity);
                }
            }

            return entity;
        }

        #endregion

        #region Static methods

        private static void RegisterFormatter<TEntity>(object formatter)
        {
            Formatters.Add(typeof(TEntity), formatter);
        }

        private static IEntityFormatter<TEntity> ResolveFormatter<TEntity>(TEntity entity)
        {
            IEntityFormatter<TEntity> result = null;
            Type entityType = typeof(TEntity);

            if (Formatters.ContainsKey(entityType))
            {
                result = (IEntityFormatter<TEntity>)Formatters[entityType];
            }

            return result;
        }

        #endregion
    }
}