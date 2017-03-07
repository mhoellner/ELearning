namespace ELearning.Models
{
    public class FormResultSerializable
    {
        public string FormId { get; set; }
        public int NumberOfResults { get; set; }
        public QuestionSerializable[] Questions { get; set; }
    }

    public class QuestionSerializable
    {
        public string QuestionId { get; set; }
        public AnswerSerializable[] Answers { get; set; }
    }

    public class AnswerSerializable
    {
        public string AnswerId { get; set; }
        public int AmountOfRightAnswers { get; set; }
    }
}