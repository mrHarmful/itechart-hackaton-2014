using Seed.Dacs.Interfaces;
using Seed.Dacs.MsSql.Components.MsSqlComponents;

namespace Seed.Dacs.MsSql.Components
{
    public class DacFactory : IDacFactory
    {
        public ICommonDac GetSampleDac()
        {
            return new MsSqlCommonDacImpl();
        }

        public IQuizDac GetQuizDac()
        {
            return new MsSqlQuizDac();
        }
    }
}
