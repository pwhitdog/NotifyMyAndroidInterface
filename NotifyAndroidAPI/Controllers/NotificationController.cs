using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml;
using NotifyAndroidAPI.Models;
using NotifyMyAndroid.Core.Services;

namespace NotifyAndroidAPI.Controllers
{
    public class NotificationController : ApiController
    {
        
        private const string NotifyExt = "publicapi/notify?";
        
        // GET api/notification/5
        [HttpGet]
        public string Verify(string apikey)
        {
            apikey = "apikey=" + apikey;

            var response = VerifyService.CallNotifyVerify(apikey);
            var parsedXml = VerifyService.ParseXML(response);

            Debug.WriteLine("The answer is: " + parsedXml.Code);
            return parsedXml.Code;
        }

        // POST api/notification
        public void Post([FromBody]string value)
        {
        }

    }

}
