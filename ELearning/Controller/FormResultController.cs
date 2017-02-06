using System.Linq;
using System.Web.Mvc;
using ELearning.Models;
using Our.Umbraco.Ditto;
using Umbraco.Web.Models;

namespace ELearning.Controller
{
    public class FormResultController : Umbraco.Web.Mvc.RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            int allCorrectAnswers = 0;
            int yourCorrectAnswers = 0;

            // POST-Arguments
            string formId = Request.Form["formId"];
            string[] args = Request.Form.ToString().Split('&');

            //Get amount of all correct answers for the current form
            Form form = Umbraco.TypedContent(formId).As<Form>();
            foreach (QuestionItem question in form.Questions)
            {
                allCorrectAnswers += question.Children.Count(c => c.DocumentTypeAlias == "correctAnswer");
            }

            for (int i = 1; i < args.Length; i++)
            {
                //Get amount of correct answers in the current request
                string answerId = args[i].Split('=')[1];
                string docAlias = Umbraco.TypedContent(answerId).DocumentTypeAlias;
                if (docAlias == "correctAnswer")
                {
                    yourCorrectAnswers++;
                }
                else if (docAlias == "wrongAnswer")
                {
                    yourCorrectAnswers--;
                }
            }
            //Minimum for correct answers is 0
            if (yourCorrectAnswers < 0)
            {
                yourCorrectAnswers = 0;
            }
            var formResult = new FormResult(Umbraco.AssignedContentItem)
            {
                FormId = int.Parse(formId),
                YourCorrectAnswers = yourCorrectAnswers,
                AllCorrectAnswers = allCorrectAnswers,
                FormTitle = "Auswertung"
            };
            return View("~/Views/FormResult.cshtml", (object) formResult);
        }
    }
}