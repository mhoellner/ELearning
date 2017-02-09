using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Umbraco.Web.WebApi;

namespace ELearning.Controller
{
    public class LoginController : UmbracoApiController
    {
        private bool _loginStatus = false;
        public bool LoggedIn()
        {
            return _loginStatus;
        }
        
        [HttpGet]
        public async Task<string> Login(string name, string password)
        {
            string post_data = "name=" + name + "&password=" + password;
            string loginUrl = "https://webmail.stud.hwr-berlin.de/ajax/login?action=login";
            string nameUrl = "https://webmail.stud.hwr-berlin.de/ajax/contacts?action=getuser";
            string loginResponseString = "empty";
            string nameResponseString = "empty";
            string sessionID = "empty";
            string userID = "empty";
            string displayName = "Mustermann, Max";

            using (HttpClient client = new HttpClient())
            {
                Dictionary<string, string> postdata = new Dictionary<string, string>
                {
                    {"name", name },
                    {"password", password }
                };
                FormUrlEncodedContent content = new FormUrlEncodedContent(postdata);
                HttpResponseMessage response = await client.PostAsync(loginUrl, content);
                loginResponseString = await response.Content.ReadAsStringAsync();
                _loginStatus = loginResponseString.Contains("session");

                if (loginResponseString.Contains("session"))
                {
                    string[] s = loginResponseString.Split(',');
                    sessionID = s[0].Split(':')[1].Substring(1, s[0].Split(':')[1].Length - 2);
                    userID = s[2].Split(':')[1];

                    postdata = new Dictionary<string, string>
                    {
                        {"session", sessionID },
                        {"id", userID }
                    };
                    content = new FormUrlEncodedContent(postdata);
                    response = await client.PostAsync(nameUrl, content);
                    nameResponseString = await response.Content.ReadAsStringAsync();

                    int firstLetterOfDisplayName = nameResponseString.IndexOf("display_name\":\"") + 15;
                    int indexOfNextQuotationMark = nameResponseString.IndexOf("\"", firstLetterOfDisplayName);
                    int lengthOfDisplayName = indexOfNextQuotationMark - firstLetterOfDisplayName;
                    displayName = nameResponseString.Substring(
                        firstLetterOfDisplayName,
                        lengthOfDisplayName);
                }
            }
            return loginResponseString;
        }
    }
}