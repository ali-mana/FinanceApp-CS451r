using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancingApp.Model.CodeFirst
{
    [Table("Address")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AddressId { get; set; }
        
        [Required]
        public string AddressLine1 { get; set; }

        public string AddressLin2 { get; set; }

        [Required]
        public string City { get; set; }

    }
}
