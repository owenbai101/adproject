﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LastADEntities : DbContext
    {
        public LastADEntities()
            : base("name=LastADEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdjVoucher> AdjVouchers { get; set; }
        public virtual DbSet<CollectionPoint> CollectionPoints { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<ItemList> ItemLists { get; set; }
        public virtual DbSet<ItemSupplier> ItemSuppliers { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<RequDetail> RequDetails { get; set; }
        public virtual DbSet<Requisition> Requisitions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
    }
}