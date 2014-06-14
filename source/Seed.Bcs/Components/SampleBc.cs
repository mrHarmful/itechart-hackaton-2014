using System;
using System.Collections.Generic;
using System.Linq;
using Seed.Dacs.Interfaces;
using Seed.Entities;

namespace Seed.Bcs
{
    public class SampleBc
    {
        #region Private fields

        private readonly ISampleDac _sampleDac;

        #endregion

        #region Singleton

        private static SampleBc _sampleBc;

        private static readonly object Locker;

        static SampleBc()
        {
            Locker = new object();
        }

        private SampleBc()
        {
            _sampleDac = DacFactoryClient.GetConcreteFactory().GetSampleDac();
        }

        public static SampleBc Instance
        {
            get
            {
                if (_sampleBc == null)
                {
                    lock (Locker)
                    {
                        if (_sampleBc == null)
                        {
                            _sampleBc = new SampleBc();
                        }
                    }
                }

                return _sampleBc;
            }
        }

        #endregion

        #region Public methods

        public List<KeyValueItem> GetTargets()
        {
            throw new NotImplementedException();
        }

        public List<KeyValueItem> GetPriorities()
        {
            throw new NotImplementedException();
        }

        public List<KeyValueItem> GetCategories()
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}