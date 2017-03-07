using System.IO;
using System.Linq;
using System.Web.Mvc;
using ELearning.Models;
using Newtonsoft.Json;
using Our.Umbraco.Ditto;
using Umbraco.Web.Models;

namespace ELearning.Controller
{
    /// <summary>
    /// Executes for all contents with the FormResult-Template.
    /// </summary>
    public class FormResultController : Umbraco.Web.Mvc.RenderMvcController
    {
        private int _allCorrectAnswers;
        private int _yourCorrectAnswers;
        private string _formId;
        private FormResultSerializable _json;
        private string _jsonPath = "/formresults/";

        public override ActionResult Index(RenderModel model)
        {
            _allCorrectAnswers = 0;
            _yourCorrectAnswers = 0;

            // POST-Arguments
            _formId = Request.Form["formId"];
            string[] args = Request.Form.ToString().Split('&');

            //Trying to create a json file
            InitializeJson();
            SaveJson();

            //Get amount of all correct answers for the current form
            Form form = Umbraco.TypedContent(_formId).As<Form>();
            foreach (QuestionItem question in form.Questions)
            {
                _allCorrectAnswers += question.Children.Count(c => c.DocumentTypeAlias == "correctAnswer");
            }
            
            CalculateAmountOfCorrectAnswers(args);

            //Minimum for correct answers is 0
            if (_yourCorrectAnswers < 0)
            {
                _yourCorrectAnswers = 0;
            }

            return View("~/Views/FormResult.cshtml", BuildModel());
        }

        /// <summary>
        /// Calculate the amount of correct answers in the current POST-request
        /// </summary>
        /// <param name="args">the POST-args</param>
        private void CalculateAmountOfCorrectAnswers(string[] args)
        {
            for (int i = 1; i < args.Length; i++)
            {
                string answerId = args[i].Split('=')[1];
                string docAlias = Umbraco.TypedContent(answerId).DocumentTypeAlias;
                if (docAlias == "correctAnswer")
                {
                    _yourCorrectAnswers++;
                }
                else if (docAlias == "wrongAnswer")
                {
                    _yourCorrectAnswers--;
                }
            }
        }

        /// <summary>
        /// Creates a Model to show in the View
        /// </summary>
        /// <returns>The freshly build model</returns>
        private FormResult BuildModel()
        {
            return new FormResult(Umbraco.AssignedContentItem)
            {
                FormId = int.Parse(_formId),
                YourCorrectAnswers = _yourCorrectAnswers,
                AllCorrectAnswers = _allCorrectAnswers,
                FormTitle = "Auswertung"
            };
        }

        /// <summary>
        /// The Path to the json file
        /// </summary>
        /// <returns>path</returns>
        private string PathWithFilename()
        {
            return _jsonPath + _formId + ".json";
        }

        /// <summary>
        /// Read json from file if it exists, otherwise create a new json
        /// </summary>
        private void ReadJson()
        {
            if (JsonFileExists())
            {
                //Open file
                using (StreamReader reader = new StreamReader(PathWithFilename()))
                {
                    string text = reader.ReadToEnd();
                    _json = JsonConvert.DeserializeObject<FormResultSerializable>(text);
                }
            }
            else
            {
                InitializeJson();
            }
        }

        /// <summary>
        /// Checks, if the file already exists
        /// </summary>
        /// <returns></returns>
        private bool JsonFileExists()
        {
            return true;
        }

        /// <summary>
        /// Saves the json to a file
        /// </summary>
        private void SaveJson()
        {
            using (StreamWriter writer = new StreamWriter(PathWithFilename()))
            {
                writer.Write(JsonConvert.SerializeObject(_json, Formatting.Indented));
            }
        }

        /// <summary>
        /// Creates a new json object
        /// </summary>
        private void InitializeJson()
        {
            _json = new FormResultSerializable();
            _json.FormId = _formId;
            _json.NumberOfResults = 0;
            _json.Questions = new[]
            {
                new QuestionSerializable
                {
                    QuestionId = "1000",
                    Answers = new[]
                    {
                        new AnswerSerializable
                        {
                            AnswerId = "1001",
                            AmountOfRightAnswers = 0
                        }
                    }
                }
            };
        }
    }
}