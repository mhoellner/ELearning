using System.Web;
using Our.Umbraco.Ditto;

namespace ELearning.Models
{
    public class QuestionItem : Item
    {
        [UmbracoProperty("frage")]
        public HtmlString Question { get; set; }
    }
}