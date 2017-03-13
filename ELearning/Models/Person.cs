using System.Web;

namespace ELearning.Models
{
    /// <summary>
    /// Model for all Profiles
    /// </summary>
    public class Person : Item
    {
        public string ProfilePic { get; set; }
        public HtmlString ProfileDescription { get; set; }
    }
}