//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Sup_Requst_Detailes
    {
        public int perem_Num { get; set; }
        public Nullable<int> War_Id { get; set; }
        public int Prod_Id { get; set; }
        public Nullable<int> IQuntity { get; set; }
        public Nullable<System.DateTime> Expire { get; set; }
        public Nullable<System.DateTime> production_Date { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual SupPermission SupPermission { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}