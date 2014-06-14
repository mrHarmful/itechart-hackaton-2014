namespace Seed.Entities.AccountItems
{
    public class UserQuizList
    {
        public ItemsList<Quiz> Quizzes { get; set; }

        public ItemsList<SingleQuestion> Questions { get; set; }
    }
}