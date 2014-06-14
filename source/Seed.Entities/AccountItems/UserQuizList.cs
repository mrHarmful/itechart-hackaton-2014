using System.Collections.Generic;

namespace Seed.Entities.AccountItems
{
    public class UserQuizList
    {
        public List<Quiz> Quizzes { get; set; }

        public List<SingleQuestion> Questions { get; set; }
    }
}