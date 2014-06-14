using System;
using System.Collections.Generic;

namespace Seed.Entities
{
    public class Quiz
    {
        public Quiz()
        {
            Questions = new List<Question>();
            Targets = new List<long>();
        }

        public long OwnerId { get; set; }

        public long? Id { get; set; }

        public string Title { get; set; }

        public string Reason { get; set; }

        public long CategoryId { get; set; }

        public List<Question> Questions { get; set; }

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
    }
}