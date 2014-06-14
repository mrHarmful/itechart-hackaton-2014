using Seed.Dacs.Interfaces;

namespace Seed.Dacs.Interfaces
{
    public interface IDacFactory
    {
        ICommonDac GetSampleDac();

        IQuizDac GetQuizDac();
    }
}