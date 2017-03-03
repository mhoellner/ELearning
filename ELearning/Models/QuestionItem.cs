using System.Web;
using Our.Umbraco.Ditto;

namespace ELearning.Models
{
    /// <summary>
    /// Model for our Questions
    /// </summary>
    public class QuestionItem : Item
    {
        [UmbracoProperty("frage")]
        public HtmlString Question { get; set; }
    }
}