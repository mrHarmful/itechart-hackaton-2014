using System.Collections.Generic;

namespace Seed.Entities.AccountItems
{
    public class UserQuizList : QuizList
    {
        public List<SingleQuestion> Questions { get; set; }
    }
}