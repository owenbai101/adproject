using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Team4_Ad.WCF
{
    [DataContract]
    public class WCF_RequisitionDetailJoinItemList
    {
        [DataMember]
        public string itemid { get; set; }

        [DataMember]
        public string itemname { get; set; }

        [DataMember]
        public int? Quantity { get; set; }

        [DataMember]
        public string RetrievalQuantity { get; set; }


        [DataMember]
        public string uom { get; set; }

        [DataMember]
        public string bin { get; set; }

        [DataMember]
        public string token { get; set; }


    }
}