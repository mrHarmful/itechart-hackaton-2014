using System;
using System.Collections.Generic;

namespace Seed.Entities
{
    public class SingleQuestion : Question
    {
        public long CategoryId { get; set; }

        public List<long> Targets { get; set; }

        public DateTime StartDate
        {
            get { return new DateTime(1969, 1, 1); }
            set { }
        }

        public DateTime EndDate
        {
            get { return new DateTime(2040, 1, 1); }
            set { }
        }

        public long PriorityId { get; set; }

        public SingleQuestion()
        {
            Targets = new List<long>();
        }
    }
}
