using System;
using System.Runtime.Serialization;

namespace NotifyAndroidAPI.Models
{
    [Serializable]
    [DataContract]
    public class ValidityAnswer
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Error { get; set; }
        [DataMember]
        public string ResetTimer { get; set; }
        [DataMember]
        public string Remaining { get; set; }
    }
}