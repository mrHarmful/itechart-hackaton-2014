using Seed.Dacs.Interfaces;

namespace Seed.Dacs.Interfaces
{
    public interface IDacFactory
    {
        ISampleDac GetSampleDac();

        IQuizDac GetQuizDac();
    }
}