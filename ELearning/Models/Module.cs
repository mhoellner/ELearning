using System.Collections.Generic;
using System.Web;
using Our.Umbraco.Ditto;
using Umbraco.Web;

namespace ELearning.Models
{
    /// <summary>
    /// Model for our Module-Views.
    /// </summary>
    public class Module : Item
    {
        public HtmlString Description { get; set; }

        [UmbracoProperty("zugehoerigeWissenstests")]
        public string FormIDs { get; set; }

        [UmbracoProperty("zugehoerigeLerninhalte")]
        public string VideoIDs { get; set; }

        [UmbracoProperty("ansprechpartner")]
        public string UserIDs { get; set; }

        [DittoIgnore]
        public IEnumerable<Form> Forms
        {
            get
            {
                IEnumerable<string> ids = FormIDs.Split(',');
                return new UmbracoHelper(UmbracoContext.Current).TypedContent(ids).As<Form>();
            }
        }

        [DittoIgnore]
        public IEnumerable<Video> Videos
        {
            get
            {
                IEnumerable<string> ids = VideoIDs.Split(',');
                return new UmbracoHelper(UmbracoContext.Current).TypedContent(ids).As<Video>();
            }
        }

        [DittoIgnore]
        public IEnumerable<Person> Users
        {
            get
            {
                IEnumerable<string> ids = UserIDs.Split(',');
                return new UmbracoHelper(UmbracoContext.Current).TypedContent(ids).As<Person>();
            }
        }
    }
}