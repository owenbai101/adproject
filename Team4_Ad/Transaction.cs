//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Team4_Ad
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public string ItemId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Balance { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<int> Requid { get; set; }
        public Nullable<int> PurchaseOrderId { get; set; }
        public Nullable<int> AdjVoucherId { get; set; }
    
        public virtual AdjVoucher AdjVoucher { get; set; }
        public virtual ItemList ItemList { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual Requisition Requisition { get; set; }
    }
}
