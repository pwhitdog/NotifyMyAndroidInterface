using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Xml;
using NotifyAndroidAPI.Models;

namespace NotifyMyAndroid.Core.Services
{
    public class PostService : IPostService
    {
        private const string Url = "https://www.notifymyandroid.com/publicapi/notify";
        private readonly NameValueCollection data = new NameValueCollection();

        public XmlDocument SendMessage(Notification notification)
        {
            string responseString;
            var xmlDoc = new XmlDocument();

            SetData(notification);

            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues(Url, "POST", data);

                responseString = Encoding.Default.GetString(response);
                xmlDoc.LoadXml(responseString);
            }
            ;


            return (xmlDoc);
        }

        private void SetData(Notification notification)
        {
            data["apikey"] = notification.Apikey;
            data["application"] = notification.ApplicationName;
            data["event"] = notification.Event;
            data["description"] = notification.Description;
            data["priority"] = notification.Priority.ToString();
            if (notification.DeveloperKey != 0)
            {
                data["developerkey"] = notification.DeveloperKey.ToString();
            }
            if (notification.UrlInNotification != "")
            {
                data["url"] = notification.UrlInNotification;
            }
            if (notification.HtmlAdded != false)
            {
                data["content-type"] = notification.HtmlAdded.ToString();
            }
        }
    }

    public interface IPostService
    {
        XmlDocument SendMessage(Notification notification);
    }
}