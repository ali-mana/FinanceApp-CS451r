//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinancingApp1.Model.DbFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Equipment
    {
        public long EquipmentId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Cost { get; set; }
        public long AddressId { get; set; }
    
        public virtual Address Address { get; set; }
    }
}
