using System.Web.Mvc;
using ELearning.Models;
using Our.Umbraco.Ditto;
using Umbraco.Web.Models;

namespace ELearning.Controller
{
    public class StatisticsController : Umbraco.Web.Mvc.RenderMvcController
    {
        [HttpGet]
        public override ActionResult Index(RenderModel model)
        {
            Statistics stats = new Statistics(Umbraco.AssignedContentItem)
            {
                Title = (string) model.Content.GetProperty("title").Value,
                FormsFolder = (int) model.Content.GetProperty("formsFolder").Value
            };
            return CurrentTemplate(stats);
        }
    }
}