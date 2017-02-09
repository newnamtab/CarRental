using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_AVIS
{
    [DataContract]
    [Serializable]
    public class RentalStation
    {
        [DataMember]
        public string StationCode { get; set; }
        [DataMember]
        public int StationId { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string TelephoneNumber { get; set; }
    }
}