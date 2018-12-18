using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team4_Ad.WCF
{
    [DataContract]
    public class WCF_User
    {
        [DataMember]

        public string name;
      

        [DataMember]
        public string token;


        [DataMember]
        public string department;

        [DataMember]
        public string password;

        [DataMember]
        public string status;


    }
}