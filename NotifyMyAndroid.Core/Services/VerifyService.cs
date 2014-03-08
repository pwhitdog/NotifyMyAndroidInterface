using System;
using System.Net;
using System.Xml;
using NotifyAndroidAPI.Models;

namespace NotifyMyAndroid.Core.Services
{
    public class VerifyService : IVerifyService
    {
        private const string BaseUrl = "https://www.notifymyandroid.com/";
        private const string VerifyExt = "publicapi/verify?";

        ValidityAnswer IVerifyService.ParseXML(XmlDocument xmlDocument)
        {
            return ParseXML(xmlDocument);
        }

        XmlDocument IVerifyService.CallNotifyVerify(string apiKey)
        {
            return CallNotifyVerify(apiKey);
        }

        public static XmlDocument CallNotifyVerify(string apiKey)
        {
            try
            {
                string fullUri = BaseUrl + VerifyExt + apiKey;
                var request = WebRequest.Create(fullUri) as HttpWebRequest;
                var response = request.GetResponse() as HttpWebResponse;

                var xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                return (xmlDoc);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.Read();
                return null;
            }
        }

        public static ValidityAnswer ParseXML(XmlDocument xmlDocument)
        {
            var _validityAnswer = new ValidityAnswer();
            XmlNode node = xmlDocument.DocumentElement.FirstChild;
            _validityAnswer.Code = node.Attributes.GetNamedItem("code").InnerText;

            if (_validityAnswer.Code != "200")
            {
                _validityAnswer.Error = node.InnerText;
            }
            else
            {
                _validityAnswer.Remaining = node.Attributes.GetNamedItem("remaining").InnerText;
                _validityAnswer.ResetTimer = node.Attributes.GetNamedItem("resettimer").InnerText;
            }

            return _validityAnswer;
        }
    }

    public interface IVerifyService
    {
        XmlDocument CallNotifyVerify(string apiKey);
        ValidityAnswer ParseXML(XmlDocument xmlDocument);
    }
}