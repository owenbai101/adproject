using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Team4_Ad
{
    [DataContract]
    public class WCF_RequsitionJoinEmployee
    {
        [DataMember]
        public int Requid { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string SubmittedDate { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string SignBy { get; set; }
        [DataMember]
        public string SignDate { get; set; }

        [DataMember]
        public string token { get; set; }

        [DataMember]
        public string DepartmentCode { get; set; }




    }
}