using System.Collections.Generic;
using System.Web;
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

        private static int CurrentpPoints = 23;

        public PointsStatus CheckPoints()
        {
            var status = new PointsStatus();

            var currentpPoints = CurrentpPoints + 20;
            var oldPoints = currentpPoints;

            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                object sessionData = HttpContext.Current.Session["points"];

                oldPoints = sessionData != null ? (int) sessionData : 0;
            }
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["points"] = currentpPoints;
            }

            if(oldPoints != currentpPoints)
            {
                status.IsIncreased = oldPoints < currentpPoints;
                status.Change = currentpPoints - oldPoints;
                status.Total = currentpPoints;

                return status;
            }

            return null;
        }

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