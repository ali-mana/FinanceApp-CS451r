//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinancingApp.Model.DbFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalesRepresentative
    {
        public SalesRepresentative()
        {
            this.VendorSalesRepresentatives = new HashSet<VendorSalesRepresentative>();
            this.Applications = new HashSet<Application>();
        }
    
        public long SalesRepresentativeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public long ProfileId { get; set; }
    
        public virtual Profile Profile { get; set; }
        public virtual ICollection<VendorSalesRepresentative> VendorSalesRepresentatives { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}
