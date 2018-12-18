using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team4_Ad.WCF
{
    [DataContract]
    public class WCF_RequisitionDetail
    {
        [DataMember]

        public string Requid { get; set; }
     
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string quantity { get; set; }

        [DataMember]

        public string itemid { get; set; }

        [DataMember]

        public string OutstandingQuantity { get; set; }

        [DataMember]

        public string EmployeeName { get; set; }
        [DataMember]
        public string token { get; set; }






    }
}