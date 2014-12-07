using FinancingApp.Model.DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancingApp.Web.Models
{
    public class ApplicationIndexViewModel
    {
        public IList<Application> Applications { get; set; }

        
    }
}