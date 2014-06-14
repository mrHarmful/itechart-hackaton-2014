﻿using Seed.Dacs.Interfaces;
using Seed.Dacs.MsSql.Components.MsSqlCommands;
using Seed.Entities;

namespace Seed.Dacs.MsSql.Components.MsSqlComponents
{
    public class MsSqlCommonDacImpl : ICommonDac
    {
        public Sample GetSample()
        {
            var command = new GetSampleCommand();

            command.Execute();

            return command.CommandResult;
        }
    }
}