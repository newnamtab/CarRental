using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using WCF_AVIS.Models;

namespace WCF_AVIS
{
    [DataContract]
    [Serializable]
    public class RentalAgent
    {
        [DataMember]
        public int AgentId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public RentalStation PrimaryLocation { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Salt { get; set; }
        [DataMember]
        public string HashPass { get; set; }

        public RentalAgent(string fname, string lname, string uname, int aid, string sal, string hpass, RentalStation loka)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.UserName = uname;
            this.AgentId = aid;
            this.Salt = sal;
            this.HashPass = new LoginHelper().Hasher(hpass, sal);
            this.PrimaryLocation = loka;
        }
    }
}