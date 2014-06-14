namespace Seed.Entities
{
    public class Answer
    {
        public long OwnerId { get; set; }

        public long? Id { get; set; }

        public long QuestionId { get; set; }

        public string Caption { get; set; }
    }
}