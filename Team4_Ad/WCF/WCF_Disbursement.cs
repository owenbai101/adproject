using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Team4_Ad.WCF
{
    [DataContract]
    public class WCF_Disbursement
    {
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Quantity { get; set; }
        [DataMember]
        public string token { get; set; }

        public WCF_Disbursement(string Description, string Quantity)
        {
            this.Description = Description;
            this.Quantity = Quantity;
            

        }
    }
}