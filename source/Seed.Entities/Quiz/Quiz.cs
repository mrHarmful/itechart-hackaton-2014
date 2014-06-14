using System;
using System.Collections.Generic;
using Seed.Entities.Enums;

namespace Seed.Entities
{
    public class Quiz
    {
        public long OwnerId { get; set; }

        public long Id { get; set; }

        public string Title { get; set; }

        public string Reason { get; set; }

        public Category Category { get; set; }

        private List<Question> Questions { get; set; }

        public List<Department> Target { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public QuizPriority Priority { get; set; }

        public Quiz()
        {
            Questions = new List<Question>();
            Target = new List<Department>();
        }
    }
}
