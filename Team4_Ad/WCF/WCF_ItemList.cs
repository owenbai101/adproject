using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Team4_Ad.WCF
{
    [DataContract]
    public class WCF_ItemList
    {
        [DataMember]

        public string itemid;

        [DataMember]
        public string name;
        [DataMember]
        public string Bin;
        [DataMember]
        public String Stock;
        [DataMember]
        public string token { get; set; }

        public WCF_ItemList(string itemid, string name, string Bin, string
            Stock)
        {
            this.itemid = itemid;
            this.name = name;
            this.Bin = Bin;
            this.Stock = Stock;
        
        }
    }
}