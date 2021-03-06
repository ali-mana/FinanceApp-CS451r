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
    
    public partial class Address
    {
        public Address()
        {
            this.Customers = new HashSet<Customer>();
            this.Equipments = new HashSet<Equipment>();
            this.Vendors = new HashSet<Vendor>();
        }
    
        public long AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
    
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}
