using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCF_AVIS
{
    [DataContract]
    [Serializable]
    public class Car
    {
        [DataMember]
        public string NumberPlate { get; set; }
        [DataMember]
        public string Make { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public CarCategory Category { get; set; }
        [DataMember]
        public int Odometer { get; set; }
        [DataMember]
        public string Colour { get; set; }
    }
}