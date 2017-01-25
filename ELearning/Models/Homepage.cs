using System.Web;

namespace ELearning.Models
{
    public class Homepage : Item
    {
        public HtmlString SiteDescription { get; set; }
        public string SiteTitle { get; set; }
        public string SiteLogo { get; set; }
    }
}