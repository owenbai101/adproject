using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Team4_Ad.WCF
{
    [DataContract]
    public class WCF_AdjVoucher
    {
        [DataMember]
        public string ItemId { get; set; }

        [DataMember]
        public string QuantityAdj { get; set; }

        [DataMember]
        public string Reason { get; set; }

        [DataMember]
        public string RequestEmpNum { get; set; }

        [DataMember]
        public string token { get; set; }






    }
}