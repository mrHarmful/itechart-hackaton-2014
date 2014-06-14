using Seed.Dacs.Interfaces;
using Seed.Dacs.MsSql.Components;

namespace Seed.Bcs
{
    internal class DacFactoryClient
    {
        private static IDacFactory _dacFactory;

        private static readonly object Locker;

        static DacFactoryClient()
        {
            Locker = new object();
        }

        private DacFactoryClient() {}

        public static IDacFactory GetConcreteFactory()
        {
            if (_dacFactory == null)
            {
                lock (Locker)
                {
                    if (_dacFactory == null)
                    {
                        _dacFactory = new DacFactory();
                    }
                }
            }

            return _dacFactory;
        }
    }
}