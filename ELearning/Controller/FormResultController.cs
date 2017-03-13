using System.Collections.Generic;
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
    /// RenderMvcControllers are auto-routed
    /// </summary>
    public class FormResultController : Umbraco.Web.Mvc.RenderMvcController
    {
        private int _allCorrectAnswers;
        private int _yourCorrectAnswers;
        private string _formId;
        private FormResultSerializable _json;
        private string _jsonPath = "/formresults";
        private Form _form;

        /// <summary>
        /// Executes, when a document of Type FormResult has to render.
        /// </summary>
        public override ActionResult Index(RenderModel model)
        {
            _allCorrectAnswers = 0;
            _yourCorrectAnswers = 0;

            // POST-Arguments
            _formId = Request.Form["formId"];
            string[] args = Request.Form.ToString().Split('&');
            
            //Get amount of all correct answers for the current form
            _form = Umbraco.TypedContent(_formId).As<Form>();

            //Trying to create a json file
            ReadJson();
            _json.NumberOfResults++;

            foreach (QuestionItem question in _form.Questions)
            {
                _allCorrectAnswers += question.Children.Count(c => c.DocumentTypeAlias == "correctAnswer");
            }
            
            CalculateAmountOfCorrectAnswers(args);

            //Minimum for correct answers is 0
            if (_yourCorrectAnswers < 0)
            {
                _yourCorrectAnswers = 0;
            }

            _json.TestResults.Add(_yourCorrectAnswers);
            
            SaveJson();

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
                IncrementAnswerTimesClicked(answerId);
            }
        }

        /// <summary>
        /// Increments the Amount of the Clicks on an answer
        /// </summary>
        /// <param name="id">The answerID</param>
        private void IncrementAnswerTimesClicked(string id)
        {
            foreach (QuestionSerializable question in _json.Questions)
            {
                if (question.Answers.Any(x => x.AnswerId == id))
                {
                    question.Answers.First(x => x.AnswerId == id).TimesClicked++;
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
            return _jsonPath + "/" + _formId + ".json";
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
            if (Directory.Exists(_jsonPath) && System.IO.File.Exists(PathWithFilename()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Saves the json to a file
        /// </summary>
        private void SaveJson()
        {
            Directory.CreateDirectory(_jsonPath);
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
            _json = new FormResultSerializable
            {
                FormId = _formId,
                NumberOfResults = 0,
                TestResults = new List<int>(),
                Questions = new QuestionSerializable[_form.Questions.Count()]
            };

            int questionCounter = 0;
            foreach (QuestionItem formQuestion in _form.Questions)
            {
                _json.Questions[questionCounter] = new QuestionSerializable
                {
                    QuestionId = formQuestion.Id.ToString(),
                    Type = formQuestion.DocumentTypeAlias,
                    Answers = new AnswerSerializable[formQuestion.Children.Count()]
                };

                int answerCounter = 0;
                foreach (AnswerItem answer in formQuestion.Children.As<AnswerItem>())
                {
                    bool isCorrect = false;

                    if (answer.DocumentTypeAlias == "correctAnswer")
                    {
                        isCorrect = true;
                    }
                    else if (answer.DocumentTypeAlias == "wrongAnswer")
                    {
                        isCorrect = false;
                    }
                    _json.Questions[questionCounter].Answers[answerCounter] = new AnswerSerializable
                    {
                        TimesClicked = 0,
                        IsCorrect = isCorrect,
                        AnswerId = answer.Id.ToString()
                    };

                    answerCounter++;
                }
                questionCounter++;
            }
        }
    }
}