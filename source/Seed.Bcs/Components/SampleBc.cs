using System;
using System.Collections.Generic;
using System.Linq;
using Seed.Dacs.Interfaces;
using Seed.Entities;

namespace Seed.Bcs
{
    public class CommonBc
    {
        #region Private fields

        private readonly ICommonDac _sampleDac;

        #endregion

        #region Singleton

        private static CommonBc _sampleBc;

        private static readonly object Locker;

        static CommonBc()
        {
            Locker = new object();
        }

        private CommonBc()
        {
            _sampleDac = DacFactoryClient.GetConcreteFactory().GetSampleDac();
        }

        public static CommonBc Instance
        {
            get
            {
                if (_sampleBc == null)
                {
                    lock (Locker)
                    {
                        if (_sampleBc == null)
                        {
                            _sampleBc = new CommonBc();
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
            var result = _sampleDac.GetTargets();

            return result;
        }

        public List<KeyValueItem> GetPriorities()
        {
            var result = _sampleDac.GetPriorities();

            return result;
        }

        public List<KeyValueItem> GetCategories()
        {
            var result = _sampleDac.GetCategories();

            return result;
        }

        public List<KeyValueItem> GetAchievements()
        {
            var result = _sampleDac.GetAchievements();

            return result;
        }

        #endregion
    }
}