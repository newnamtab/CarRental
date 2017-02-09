using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCF_AVIS
{
    [DataContract]
    [Serializable]
    public class CarCategory
    {
        [DataMember]
        public char ID { get; set; }

    }
    
}