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
    
    public partial class supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public supplier()
        {
            this.SupPermissions = new HashSet<SupPermission>();
        }
    
        public int Sup_Id { get; set; }
        public string Sup_Name { get; set; }
        public Nullable<int> Sup_phone { get; set; }
        public Nullable<int> Sup_Mobile { get; set; }
        public Nullable<int> Sup_Fax { get; set; }
        public string Sup_Email { get; set; }
        public string Sup_Website { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupPermission> SupPermissions { get; set; }
    }
}