using System.Collections.Generic;

namespace ELearning.Models
{
    public class FormResultSerializable
    {
        public string FormId { get; set; }
        public int NumberOfResults { get; set; }
        public List<int> TestResults { get; set; }
        public QuestionSerializable[] Questions { get; set; }
    }

    public class QuestionSerializable
    {
        public string QuestionId { get; set; }
        public string Type { get; set; }
        public AnswerSerializable[] Answers { get; set; }
    }

    public class AnswerSerializable
    {
        public string AnswerId { get; set; }
        public int TimesClicked { get; set; }
        public bool IsCorrect { get; set; }
    }
}