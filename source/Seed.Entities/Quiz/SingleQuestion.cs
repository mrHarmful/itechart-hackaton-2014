using System;
using System.Collections.Generic;

namespace Seed.Entities
{
    public class SingleQuestion : Question
    {
        public long CategoryId { get; set; }

        public List<long> Targets { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public long PriorityId { get; set; }

        public SingleQuestion()
        {
            Targets = new List<long>();
        }
    }
}
