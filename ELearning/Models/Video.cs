using System.Web;
using System.Web.WebPages;
using Our.Umbraco.Ditto;
using Umbraco.Core;

namespace ELearning.Models
{
    /// <summary>
    /// Model for our Video-Views.
    /// </summary>
    public class Video : Item
    {
        [UmbracoProperty("TextueberVideo")]
        public HtmlString TextAbove { get; set; }

        [UmbracoProperty("textunterVideo")]
        public HtmlString TextBelow { get; set; }

        [UmbracoProperty("youtubeLink")]
        public string YoutubeLink { get; set; }

        /// <summary>
        /// Gets the full Youtube-Embed-HTML
        /// </summary>
        [DittoIgnore]
        public HtmlString YoutubeEmbedded
        {
            get
            {
                string embedded = string.Empty;
                if (YoutubeLink.Contains("youtube.com/watch?v="))
                {
                    embedded = "https://www.youtube.com/embed/" + YoutubeLink.Substring(YoutubeLink.FindIndex(t => t.Equals('=')) + 1, 11);
                }
                else if (YoutubeLink.Contains("youtube.com/embed/"))
                {
                    embedded = YoutubeLink;
                }
                else if (!YoutubeLink.IsEmpty())
                {
                    return new HtmlString("The embedded Youtube-Link is not valid.");
                }
                if (!embedded.IsNullOrWhiteSpace())
                {
                    return new HtmlString("<div class=\"video-container\">\n" +
                                          "<iframe src = " + embedded + " frameborder=\"0\" allowfullscreen></iframe>\n" +
                                          "</div>");
                }
                return new HtmlString("");
            }
        }
    }
}