using FinancingApp.DataAcess.DBFirst;
using FinancingApp.Model.DbFirst;
using FinancingApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace FinancingApp.Web.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        // GET: Application
        public ActionResult Index()
        {
            var appRep = new ApplicationRepository();
            var model = new ApplicationIndexViewModel();
            model.Applications = appRep.GetApplications();


            return View(model);
        }



        [HttpGet]
        public ActionResult Create()
        {
            //User - Sales Rep
            //what is he doing - Submitting an app for customer
            //

            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            var email = authManager.User.FindFirst(ClaimTypes.Email).Value.ToString();


            var salesRepresentativeRepository = new SalesRepresentativeRepository();
            var salesRep = salesRepresentativeRepository.GetByProfileUsername(email);


            var model = new ApplicationCreateViewModel();

            var vendorRep = new VendorRepository();

            var vendors = vendorRep.GetSalesRepVendors(salesRep.SalesRepresentativeId);

            //TODO: filter the list to only vendors that salesrepresantive belongs to

            model.VendorList = from vendor in vendors
                               select new SelectListItem()
                               {
                                   Text = vendor.Name,
                                   Value = vendor.VendorId.ToString()
                               };

            model.Equipments = new List<Equipment>();
            model.Equipments.Add(new Equipment());
            model.Equipments[0].EquipmentId = 0;
            model.Equipments[0].Address = new Address();

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(ApplicationCreateViewModel model)
        {
            var applicationRep = new ApplicationRepository();

            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            var email = authManager.User.FindFirst(ClaimTypes.Email).Value.ToString();


            var salesRepresentativeRepository = new SalesRepresentativeRepository();
            var salesRep = salesRepresentativeRepository.GetByProfileUsername(email);




            model.Application.SalesRepresentativeId = salesRep.SalesRepresentativeId;
            var vendorRep = new VendorRepository();

            var vendors = vendorRep.GetVendors();


            //TODO: filter the list to only vendors that salesrepresantive belongs to

            model.VendorList = from vendor in vendors
                               select new SelectListItem()
                               {
                                   Text = vendor.Name,
                                   Value = vendor.VendorId.ToString()
                               };
            // foreach (var vendor in model.VendorList)
            // {
            //  var VendorId = vendorRep.GetById(Int32.Parse(model.SelectedVendor)).VendorId;
            // VendorId  
            //}



            model.Application.VendorId = Int32.Parse(model.SelectedVendor);

            var customerRepository = new CustomerRepository();
            var customer = customerRepository.GetBySSN(model.Application.Customer.SSN);


            model.Application.CustomerId = customer.CustomerId;
            model.Application.Customer = null;




            Random r = new Random();
            int RandomNum = r.Next(0, 1000000);
            string RandomNumber = RandomNum.ToString("000000");

            model.Application.ConfirmationNumber = "APP" + RandomNumber.ToString();
            model.Application.Status = "Received";

            ViewData["confirmation number"] = model.Application.ConfirmationNumber;





            applicationRep.Create(model.Application);

            var Equipmentrepository = new EquipmentRepository();
            //Save equiments

            for (int i = 0; i < model.Equipments.Count; i++)
            {

                Equipment equipment = new Equipment();

                equipment.Name = model.Equipments[i].Name;
                equipment.Cost = model.Equipments[i].Cost;
                equipment.Address = new Address();
                equipment.Address.AddressLine1 = model.Equipments[i].Address.AddressLine1;
                equipment.Address.AddressLine2 = model.Equipments[i].Address.AddressLine2;
                equipment.Address.City = model.Equipments[i].Address.City;
                equipment.Address.State = model.Equipments[i].Address.State;
                equipment.Address.Zipcode = model.Equipments[i].Address.Zipcode;

                Equipmentrepository.Create(equipment);

            }

            return View("ApplicationConfirmation");
        }

        [HttpGet]
        public ActionResult AddEquipment(int index)
        {
            Equipment equipment = new Equipment();
            equipment.EquipmentId = index;
            equipment.Address = new Address();
            return PartialView("_AddEquipment", equipment);
        }
    }
}