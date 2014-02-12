using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotifyAndroidAPI.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Apikey { get; set; }
        public string ApplicationName { get; set; }
        public string Description { get; set; }
        public string Event { get; set; }
        public int? Priority { get; set; }
        public int? DeveloperKey { get; set; }
        public string UrlInNotification { get; set; }
        public bool HtmlAdded { get; set; }
    }
}