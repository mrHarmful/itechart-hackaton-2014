using System.Collections.Generic;
using Seed.Entities;

namespace Seed.Dacs.Interfaces
{
    public interface ICommonDac
    {
        List<KeyValueItem> GetTargets();

        List<KeyValueItem> GetPriorities();

        List<KeyValueItem> GetCategories();

        List<KeyValueItem> GetAchievements();

        int GetUserPoints(long userId);
    }
}