﻿using System.Collections.Generic;

namespace Seed.Entities
{
    public class Question
    {
        public long OwnerId { get; set; }

        public long? Id { get; set; }

        public long? QuizId { get; set; }

        public string Enquiry { get; set; }

        public bool IsSingleSelect { get; set; }

        public bool CanSkip { get; set; }

        public bool IsUserMeta { get; set; }

        public List<Answer> Answers { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}