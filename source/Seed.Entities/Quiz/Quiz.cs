using System;
using System.Collections.Generic;

namespace Seed.Entities
{
    public class Quiz
    {
        public long OwnerId { get; set; }

        public long Id { get; set; }

        public string Title { get; set; }

        public string Reason { get; set; }

        public long CategoryId { get; set; }

        public List<Question> Questions { get; set; }

        public List<long> Targets { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public long PriorityId { get; set; }

        public Quiz()
        {
            Questions = new List<Question>();
            Targets = new List<long>();
        }
    }
}
