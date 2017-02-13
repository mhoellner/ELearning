using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Umbraco.Web.WebApi;

namespace ELearning.Controller
{
    public class LoginController : UmbracoApiController
    {
        [HttpGet]
        public async Task<string> Login(string name, string password)
        {
            string loginUrl = "https://webmail.stud.hwr-berlin.de/ajax/login?action=login";
            string nameUrl = "https://webmail.stud.hwr-berlin.de/ajax/contacts?action=getuser";

            using (HttpClient client = new HttpClient())
            {
                Dictionary<string, string> postdata = new Dictionary<string, string>
                {
                    {"name", name },
                    {"password", password }
                };
                FormUrlEncodedContent content = new FormUrlEncodedContent(postdata);
                HttpResponseMessage response = await client.PostAsync(loginUrl, content);
                string loginResponseString = await response.Content.ReadAsStringAsync();
                var loginJson = System.Web.Helpers.Json.Decode<Dictionary<string, string>>(loginResponseString);
                if (loginJson["session"] != null)
                {
                    string sessionId = loginJson["session"];
                    string userId = loginJson["user_id"];
                    postdata = new Dictionary<string, string>
                    {
                        {"session", sessionId },
                        {"id", userId }
                    };
                    content = new FormUrlEncodedContent(postdata);
                    response = await client.PostAsync(nameUrl, content);
                    string nameResponseString = await response.Content.ReadAsStringAsync();
                    var nameJson = System.Web.Helpers.Json.Decode(nameResponseString);
                    if (nameJson.data != null)
                    {
                        return nameJson.data.display_name;
                    }
                    return "Couldn't connect to " + nameUrl;
                }
                return "Username or password is wrong.";
            }
        }
    }
}