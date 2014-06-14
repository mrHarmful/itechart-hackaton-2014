using Seed.Dacs.Interfaces;
using Seed.Dacs.MsSql.Components.MsSqlComponents;

namespace Seed.Dacs.MsSql.Components
{
    public class DacFactory : IDacFactory
    {
        public ISampleDac GetSampleDac()
        {
            return new MsSqlSampleDacImpl();
        }
    }
}
