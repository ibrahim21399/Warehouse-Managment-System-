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
    
    public partial class CusPermission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CusPermission()
        {
            this.Cus_Requst_Detailes = new HashSet<Cus_Requst_Detailes>();
        }
    
        public int prem_Num { get; set; }
        public Nullable<System.DateTime> Prem_Date { get; set; }
        public Nullable<int> prod_Quntity { get; set; }
        public Nullable<int> Cus_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cus_Requst_Detailes> Cus_Requst_Detailes { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
