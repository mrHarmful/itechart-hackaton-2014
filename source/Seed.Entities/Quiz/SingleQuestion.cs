using System;
using System.Collections.Generic;

using Seed.Entities.Enums;

namespace Seed.Entities
{
    public class SingleQuestion : Question
    {
        public Category Category { get; set; }

        public List<Department> Target { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public QuizPriority Priority { get; set; }

        public SingleQuestion()
        {
            Target = new List<Department>();
        }
    }
}
