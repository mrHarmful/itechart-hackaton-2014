using System;
using System.IO;
using log4net.Layout.Pattern;

namespace Seed.Logging.PatternConverters
{
    public class MachinePatternConverter : PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, log4net.Core.LoggingEvent loggingEvent)
        {
            writer.Write(!string.IsNullOrWhiteSpace(Environment.MachineName)
                ? Environment.MachineName
                : "Machine name does not available.");
        }
    }
}