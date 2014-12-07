using FinancingApp.Model.DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancingApp.Web.Models
{
    public class VendorIndexViewModel
    {
        public IList<Vendor> Vendors { get; set; }
    }
}