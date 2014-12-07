using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancingApp.Model.CodeFirst
{
    [Table("Vendor")]
    public  class Vendor
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long VendorId { get; set; }
        public string Name { get; set; }

        public DateTime? CreatedDated { get; set; }


        [ForeignKey("Address")]
        public long AddressId { get; set; }

        public virtual Address Address { get; set; }

    }
}
