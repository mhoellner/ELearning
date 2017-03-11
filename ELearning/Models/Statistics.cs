using System.Globalization;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace ELearning.Models
{
    public class Statistics : RenderModel
    {
        public Statistics(IPublishedContent content, CultureInfo culture) : base(content, culture)
        {
        }

        public Statistics(IPublishedContent content) : base(content)
        {
        }

        public int FormsFolder { get; set; }
        public string Title { get; set; }

        public FormResultSerializable FormResults { get; set; }
    }
}