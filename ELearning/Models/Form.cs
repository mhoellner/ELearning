using System.Collections.Generic;
using System.Linq;
using System.Web;
using Our.Umbraco.Ditto;
using Umbraco.Web;

namespace ELearning.Models
{
    /// <summary>
    /// Model for our Form-Views.
    /// </summary>
    public class Form : Item
    {
        [UmbracoProperty("einleitung")]
        public HtmlString Introduction { get; set; }

        [UmbracoProperty("fragen")]
        public string QuestionIDs { get; set; }

        [DittoIgnore]
        public IEnumerable<QuestionItem> Questions
        {
            get
            {
                IEnumerable<string> ids = QuestionIDs.Split(',').ToList();
                return new UmbracoHelper(UmbracoContext.Current).TypedContent(ids).As<QuestionItem>();
            }
        }
    }
}