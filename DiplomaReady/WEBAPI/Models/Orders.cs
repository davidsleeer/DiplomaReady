//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEBAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int CustID { get; set; }
        public string RecordID { get; set; }
        public System.DateTime DateOrdered { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        public virtual CD CD { get; set; }
        public virtual Cust Cust { get; set; }
    }
}
