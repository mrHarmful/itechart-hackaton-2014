using System.Collections.Generic;

namespace Seed.Entities
{
    public class ItemsList<T>
    {
        public List<T> Items { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public ItemsList()
        {
            Items = new List<T>();
        }
    }
}