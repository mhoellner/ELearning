using Our.Umbraco.Ditto;

namespace ELearning.Models
{
    /// <summary>
    /// Model for our Overview-Views.
    /// </summary>
    public class Overview : Item
    {
        [UmbracoProperty("ShowInBreadcrumb")]
        public bool ShowInNavigation { get; set; }
    }
}