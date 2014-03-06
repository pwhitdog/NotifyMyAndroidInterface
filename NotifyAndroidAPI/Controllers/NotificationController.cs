using System.Diagnostics;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using NotifyAndroidAPI.Models;
using NotifyMyAndroid.Core.Services;

namespace NotifyAndroidAPI.Controllers
{
    public class NotificationController : ApiController
    {
        
        // GET api/notification/5
        [System.Web.Http.HttpGet]
        public JsonResult Verify(string apikey)
        {
            apikey = "apikey=" + apikey;

            var response = VerifyService.CallNotifyVerify(apikey);
            var parsedXml = VerifyService.ParseXML(response);

            Debug.WriteLine("The answer is: " + parsedXml.Code);
            var settings = new JsonSerializerSettings();


            var model = new
            {
                responseCode = parsedXml.Code,
                responseError = parsedXml.Error,
                resetTimer = parsedXml.ResetTimer
            };

            var result = new JsonResult { Data = model };

            return result;

        }


        // POST api/notification
        [System.Web.Http.HttpPost]
        public void Post(string apikey, string applicationName, string description,
                         string eventHappening, int priority = 0, int developerkey = 0,
                         string urlnotification = "", bool htmlAdded = false)
        {
            var notifacation = new Notification
            {
                Apikey = apikey,
                ApplicationName = applicationName,
                Description = description,
                Event = eventHappening,
                Priority = priority,
                DeveloperKey = developerkey,
                HtmlAdded = htmlAdded,
                UrlInNotification = urlnotification
            };

            var response = VerifyService.CallNotifyVerify("apikey=" + apikey);
            var parsedXml = VerifyService.ParseXML(response);

            if (parsedXml.Code == "200")
            {
                var postService = new PostService();
                var isSuccessful = postService.SendMessage(notifacation);
            }

        }


    }

}
