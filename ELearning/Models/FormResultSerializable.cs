using System.Collections.Generic;

namespace ELearning.Models
{
    /// <summary>
    /// Model used with json-desrializer, represents all FormResults for a specific form
    /// </summary>
    public class FormResultSerializable
    {
        public string FormId { get; set; }
        public int NumberOfResults { get; set; }
        public List<int> TestResults { get; set; }
        public QuestionSerializable[] Questions { get; set; }
    }

    /// <summary>
    /// Model used with json-desrializer, represents all Questions for a specific form
    /// </summary>
    public class QuestionSerializable
    {
        public string QuestionId { get; set; }
        public string Type { get; set; }
        public AnswerSerializable[] Answers { get; set; }
    }

    /// <summary>
    /// Model used with json-desrializer, represents all Answers for a specific Question
    /// </summary>
    public class AnswerSerializable
    {
        public string AnswerId { get; set; }
        public int TimesClicked { get; set; }
        public bool IsCorrect { get; set; }
    }
}