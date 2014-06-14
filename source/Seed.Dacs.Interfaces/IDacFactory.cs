using Seed.Dacs.Interfaces.Components;

namespace Seed.Dacs.Interfaces
{
    public interface IDacFactory
    {
        ISampleDac GetSampleDac();

        IQuizDac GetQuizDac();
    }
}