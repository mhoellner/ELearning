using System.Globalization;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace ELearning.Models
{
    public class FormResult : RenderModel
    {
        public FormResult(IPublishedContent content, CultureInfo culture) : base(content, culture)
        {
        }

        public FormResult(IPublishedContent content) : base(content)
        {
        }


        public int FormId { get; set; }
        public string FormTitle { get; set; }
        public int YourCorrectAnswers { get; set; }
        public int AllCorrectAnswers { get; set; }
    }
}