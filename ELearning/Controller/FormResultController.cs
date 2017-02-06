using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ELearning.Models;
using Umbraco.Web.Models;

namespace ELearning.Controller
{
    public class FormResultController : Umbraco.Web.Mvc.RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            int allCorrectAnswers = 0;
            int yourCorrectAnswers = 0;
            List<string> questionIds = new List<string>();

            // POST-Arguments
            var args = Request.Form.ToString().Split('&');

            for (int i = 1; i < args.Length; i++)
            {
                string[] ids = args[i].Split('=');
                string questionId = ids[0].Substring(9);
                string answerId = ids[1].Substring(7);

                if (!questionIds.Contains(questionId))
                {
                    questionIds.Add(questionId);
                    allCorrectAnswers += Umbraco.TypedContent(questionId).Children.Count(c => c.DocumentTypeAlias == "correctAnswer");
                }
                if (Umbraco.TypedContent(answerId).DocumentTypeAlias == "correctAnswer")
                {
                    yourCorrectAnswers++;
                }
            }
            var formResult = new FormResult(Umbraco.AssignedContentItem)
            {
                FormId = int.Parse(Request.Form["formId"]),
                YourCorrectAnswers = yourCorrectAnswers,
                AllCorrectAnswers = allCorrectAnswers,
                FormTitle = "Auswertung"
            };
            return View("~/Views/FormResult.cshtml", (object) formResult);
        }
    }
}