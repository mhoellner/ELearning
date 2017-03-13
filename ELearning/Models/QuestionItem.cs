using System.Web;

namespace ELearning.Models
{
    /// <summary>
    /// Model for all Questions
    /// </summary>
    public class QuestionItem : Item
    {
        public HtmlString Question { get; set; }
    }
}