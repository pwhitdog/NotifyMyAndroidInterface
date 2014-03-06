using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NotifyAndroidAPI.Models;

namespace NotifyMyAndroid.Core.Services
{
    public class PostService : IPostService
    {
        private const string Url = "https://www.notifymyandroid.com/publicapi/notify?";

        public bool SendMessage(Notification notification)
        {
            var fullUrl = GetFullUrl(notification);

            var request = WebRequest.Create(fullUrl) as HttpWebRequest;
            var response = request.GetResponse() as HttpWebResponse;

            return true;
        }

        private string GetFullUrl(Notification notification)
        {
            var apiKey = "apikey=" + notification.Apikey;
            var appName = "application=" + notification.ApplicationName;
            var eventName = "event=" + notification.Event;
            var description = "description=" + notification.Description;
            var priority = "priority=" + notification.Priority;
            var developerKey = notification.DeveloperKey != 0 ? "developerkey=" + notification.DeveloperKey : "";
            var urlNotification = notification.UrlInNotification != "" ? "url=" + notification.UrlInNotification : "";
            var htmlAdded = notification.HtmlAdded == true ? "content-type=text/html" : "";


            return Url + apiKey + "&" + appName + "&" + eventName + "&" + description + "&" + priority + "&"
                          + developerKey + "&" + urlNotification + "&" + htmlAdded;
            
        }
    }

    public interface IPostService
    {
        bool SendMessage(Notification notification);
    }
}
