namespace Seed.Dacs.Interfaces
{
    public interface IDacFactory
    {
        /// <summary>
        /// Provides logic to get common business entities data access component.
        /// </summary>
        /// <returns>Data access component.</returns>
        ISampleDac GetSampleDac();
    }
}