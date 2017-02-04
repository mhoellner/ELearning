using System.Web.Mvc;
using ELearning.Models;
using Umbraco.Web.Models;

namespace ELearning.Controller
{
    public class FormResultController : Umbraco.Web.Mvc.RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            var args = Request.Form;
            var formResult = new FormResult(CurrentPage)
            {
                FormId = 1095,
                YourCorrectAnswers = 2,
                AllCorrectAnswers = 3,
                FormTitle = "Auswertung"
            };
            return View("~/Views/FormResult.cshtml", (object) formResult);
        }
    }
}