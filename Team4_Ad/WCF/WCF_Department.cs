using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team4_Ad.WCF
{
    [DataContract]
    public class WCF_Department
    {
        [DataMember]
        public string DepartmentCode { get; set; }
        [DataMember]
        public string CollectionPointId { get; set; }
    }
}