using System.Web;

namespace ELearning.Models
{
    /// <summary>
    /// Model for our Profile-Views.
    /// </summary>
    public class Person : Item
    {
        public string ProfilePic { get; set; }
        public HtmlString ProfileDescription { get; set; }
    }
}