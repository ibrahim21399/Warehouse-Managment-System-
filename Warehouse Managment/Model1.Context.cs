﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Warehouse_Managment
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class WarehouseEntities : DbContext
    {
        public WarehouseEntities()
            : base("name=WarehouseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cus_Requst_Detailes> Cus_Requst_Detailes { get; set; }
        public virtual DbSet<CusPermission> CusPermissions { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<product_Store> product_Store { get; set; }
        public virtual DbSet<Sup_Requst_Detailes> Sup_Requst_Detailes { get; set; }
        public virtual DbSet<SupPermission> SupPermissions { get; set; }
        public virtual DbSet<supplier> suppliers { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<product_Movement> product_Movement { get; set; }
    
        public virtual int Add_Prodect(Nullable<int> code, string name, string unit, string unit2)
        {
            var codeParameter = code.HasValue ?
                new ObjectParameter("code", code) :
                new ObjectParameter("code", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var unitParameter = unit != null ?
                new ObjectParameter("unit", unit) :
                new ObjectParameter("unit", typeof(string));
    
            var unit2Parameter = unit2 != null ?
                new ObjectParameter("unit2", unit2) :
                new ObjectParameter("unit2", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Add_Prodect", codeParameter, nameParameter, unitParameter, unit2Parameter);
        }
    
        public virtual ObjectResult<expired_Result> expired(Nullable<int> daysLeft)
        {
            var daysLeftParameter = daysLeft.HasValue ?
                new ObjectParameter("daysLeft", daysLeft) :
                new ObjectParameter("daysLeft", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<expired_Result>("expired", daysLeftParameter);
        }
    
        public virtual ObjectResult<expiredItems_Result> expiredItems(Nullable<int> daysLeft)
        {
            var daysLeftParameter = daysLeft.HasValue ?
                new ObjectParameter("daysLeft", daysLeft) :
                new ObjectParameter("daysLeft", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<expiredItems_Result>("expiredItems", daysLeftParameter);
        }
    
        public virtual ObjectResult<itemInWarehouse_Result> itemInWarehouse(string prdnsme, string w_name, Nullable<System.DateTime> date1, Nullable<System.DateTime> date2)
        {
            var prdnsmeParameter = prdnsme != null ?
                new ObjectParameter("prdnsme", prdnsme) :
                new ObjectParameter("prdnsme", typeof(string));
    
            var w_nameParameter = w_name != null ?
                new ObjectParameter("w_name", w_name) :
                new ObjectParameter("w_name", typeof(string));
    
            var date1Parameter = date1.HasValue ?
                new ObjectParameter("date1", date1) :
                new ObjectParameter("date1", typeof(System.DateTime));
    
            var date2Parameter = date2.HasValue ?
                new ObjectParameter("date2", date2) :
                new ObjectParameter("date2", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<itemInWarehouse_Result>("itemInWarehouse", prdnsmeParameter, w_nameParameter, date1Parameter, date2Parameter);
        }
    
        public virtual ObjectResult<productDuration_Result> productDuration(Nullable<int> month)
        {
            var monthParameter = month.HasValue ?
                new ObjectParameter("month", month) :
                new ObjectParameter("month", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<productDuration_Result>("productDuration", monthParameter);
        }
    
        public virtual ObjectResult<Show_Cus_Permission_Result> Show_Cus_Permission()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Show_Cus_Permission_Result>("Show_Cus_Permission");
        }
    
        public virtual ObjectResult<show_Products_Result> show_Products()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<show_Products_Result>("show_Products");
        }
    
        public virtual ObjectResult<show_productsStoresQuentity_Result> show_productsStoresQuentity()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<show_productsStoresQuentity_Result>("show_productsStoresQuentity");
        }
    
        public virtual ObjectResult<Show_Sup_Permission_Result> Show_Sup_Permission()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Show_Sup_Permission_Result>("Show_Sup_Permission");
        }
    
        public virtual ObjectResult<WarehouseDetails_Result> WarehouseDetails(string w_name, Nullable<System.DateTime> date1, Nullable<System.DateTime> date2)
        {
            var w_nameParameter = w_name != null ?
                new ObjectParameter("w_name", w_name) :
                new ObjectParameter("w_name", typeof(string));
    
            var date1Parameter = date1.HasValue ?
                new ObjectParameter("date1", date1) :
                new ObjectParameter("date1", typeof(System.DateTime));
    
            var date2Parameter = date2.HasValue ?
                new ObjectParameter("date2", date2) :
                new ObjectParameter("date2", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WarehouseDetails_Result>("WarehouseDetails", w_nameParameter, date1Parameter, date2Parameter);
        }
    }
}
