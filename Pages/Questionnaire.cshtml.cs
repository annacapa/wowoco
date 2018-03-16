using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ecard.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ecard.Pages
{
    public class QuestionnaireModel : PageModel
    {

        // WOWOCO: 1
        [BindProperty]
        public Questionnaire _myQuestionnaire { get; set; }

        // WOWOCO: 2
        private QDbBridge _myQDbBridge { get; set; }

        // WOWOCO: 3
        private IConfiguration _myConfiguration { get; set; }

        // WOWOCO: 4
        public QuestionnaireModel(QDbBridge QDbBridge, IConfiguration Configuration)
        {
            _myQDbBridge = QDbBridge;
            _myConfiguration = Configuration;

        }

        public void OnGet() { }

        [HttpPost]
        public async Task<IActionResult> OnPost()
        {

            if (await isValid())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _myQuestionnaire.created = DateTime.Now.ToString();
                        _myQuestionnaire.created_ip = this.HttpContext.Connection.RemoteIpAddress.ToString();

                        // Power of replacing inputs before they are entered into the database
                        _myQuestionnaire.favoritecolor = _myQuestionnaire.favoritecolor.Replace("\"", "&quot;");
                        _myQuestionnaire.favoritecolor = _myQuestionnaire.favoritecolor.Replace("She said, \"Hello!\"", "");

                        // DB Related add record
                        _myQDbBridge.Questionnaire.Add(_myQuestionnaire);
                        _myQDbBridge.SaveChanges();

                        //REDIRECT to the page with a new operator (name/value pair)
                        return RedirectToPage("Questionnaire", new { id = _myQuestionnaire.ID });
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return RedirectToPage("Questionnaire");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("_myQuestionnaire.reCaptcha", "Please verify you're not a robot!");
            }

            return Page();

        }

        /**
         * reCAPTHCA SERVER SIDE VALIDATION 
         * 
         *      Create an HttpClient and store the the secret/response pair
         *      Await for the sever to return a json obect 
         * */
        private async Task<bool> isValid()
        {
            var response = this.HttpContext.Request.Form["g-recaptcha-response"];
            if (string.IsNullOrEmpty(response))
                return false;

            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>();
                    //values.Add("secret", "6LfVpjEUAAAAAK0FdygAgh0P1gZ8QU24ildwT86r");
                    values.Add("secret", _myConfiguration["ReCaptcha:PrivateKey"]);

                    values.Add("response", response);
                    //values.Add("remoteip", this.HttpContext.Connection.RemoteIpAddress.ToString()); 

                    var query = new FormUrlEncodedContent(values);

                    var post = client.PostAsync("https://www.google.com/recaptcha/api/siteverify", query);

                    var json = await post.Result.Content.ReadAsStringAsync();

                    if (json == null)
                        return false;

                    var results = JsonConvert.DeserializeObject<dynamic>(json);

                    return results.success;
                }

            }
            catch { }

            return false;
        }

    }
}