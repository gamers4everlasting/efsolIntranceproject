namespace CleanArchitecture.Domain.Entities
{
    public class UserAnswers
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int QuestionId { get; set; }

        public string Answer { get; set; }

        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
    }
}
