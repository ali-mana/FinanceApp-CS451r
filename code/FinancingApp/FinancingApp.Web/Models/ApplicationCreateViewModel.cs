using FinancingApp.Model.DbFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancingApp.Web.Models
{
    public class ApplicationCreateViewModel
    {

        public Application Application { get; set; }

        public string SelectedVendor { get; set; }

        public IEnumerable<SelectListItem> VendorList { get; set; }

        public List<Equipment> Equipments { get; set; }

        public IEnumerable<SelectListItem> ApplicationList { get; set; }
       


    }
}