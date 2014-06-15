using System;
using System.Collections.Generic;
using Seed.Dacs.Interfaces;
using Seed.Dacs.MsSql.Components.MsSqlCommands.Common;
using Seed.Entities;

namespace Seed.Dacs.MsSql.Components.MsSqlComponents
{
    public class MsSqlCommonDacImpl : ICommonDac
    {
        public List<KeyValueItem> GetTargets()
        {
            var command = new GetDepartmentsCommand();

            command.Execute();

            return command.CommandResult;
        }

        public List<KeyValueItem> GetPriorities()
        {
            var command = new GetPrioritiesCommand();

            command.Execute();

            return command.CommandResult;
        }

        public List<KeyValueItem> GetCategories()
        {
            var command = new GetCategoriesCommand();

            command.Execute();

            return command.CommandResult;
        }

        public List<KeyValueItem> GetAchievements()
        {
            var command = new GetAchievementsCommand();

            command.Execute();

            return command.CommandResult;
        }

        public int GetUserPoints(long userId)
        {
            throw new NotImplementedException();
        }
    }
}