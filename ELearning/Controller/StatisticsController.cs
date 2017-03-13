using System.IO;
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
    public class StatisticsController : Umbraco.Web.Mvc.RenderMvcController
    {
        private string _id;
        private FormResultSerializable _json;
        private string _jsonPath = "/formresults";

        /// <summary>
        /// Executes, when rendering documents of Type Statistics
        /// </summary>
        public override ActionResult Index(RenderModel model)
        {
            _id = Request.Form["id"];
            ReadJson();
            model = BuildModel(model);
            return CurrentTemplate(model);
        }

        /// <summary>
        /// Workaround to use Ditto
        /// </summary>
        /// <param name="model">The current Rendermodel</param>
        /// <returns>the populated model</returns>
        private Statistics BuildModel(RenderModel model)
        {
            var viewmodel = new Statistics(Umbraco.AssignedContentItem)
            {
                Title = model.Content.As<Statistics>().Title,
                FormsFolder = model.Content.As<Statistics>().FormsFolder,
                FormResults = _json
            };

            return viewmodel;
        }

        /// <summary>
        /// The Path to the json file
        /// </summary>
        /// <returns>path</returns>
        private string PathWithFilename()
        {
            return _jsonPath + "/" + _id + ".json";
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
        }

        /// <summary>
        /// Checks, if the file already exists
        /// </summary>
        /// <returns>true, if file exists</returns>
        private bool JsonFileExists()
        {
            if (Directory.Exists(_jsonPath) && System.IO.File.Exists(PathWithFilename()))
            {
                return true;
            }
            return false;
        }
    }
}