using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCF_AVIS
{
    [DataContract]
    [Serializable]
    public class Customer
    {
        [DataMember]
        public string CustomerID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
        [DataMember]
        public string TelephoneNumber { get; set; }
        [DataMember]
        public string Email { get; set; }

    }
}