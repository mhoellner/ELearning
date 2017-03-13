using System.Web;

namespace ELearning.Models
{
    /// <summary>
    /// Model for all Homepages
    /// </summary>
    public class Homepage : Item
    {
        public HtmlString SiteDescription { get; set; }
        public string SiteTitle { get; set; }
        public string SiteLogo { get; set; }
    }
}