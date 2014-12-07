using FinancingApp.DataAcess.DBFirst;
using FinancingApp.Model.DbFirst;
using FinancingApp.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace FinancingApp.Web.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        public ActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        // POST: Security/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel Model)
        {

            //Retreive login Info from user
            var profileRep = new ProfileRepository();
            var profile = profileRep.GetByUsername(Model.Email);

            //Validate with Database

            //If succeded redirect to Home Page or show Invalid Login
            if (Model.Email == profile.Username && Model.Password == profile.Password)
            {
                string name = null;
                if (profile.ProfileType == "Representative")
                {
                    var salesRepresentativeRep = new SalesRepresentativeRepository();
                    var salesRep = salesRepresentativeRep.GetByProfileId(profile.ProfileId);

                    name = salesRep.LastName + " ," + salesRep.FirstName;
                }
                else
                {
                    //TODO:
                    var customerRep = new CustomerRepository();
                    var customerRepository = customerRep.GetByProfileId(profile.ProfileId);

                    name = customerRepository.LastName + " , " + customerRepository.FirstName;
                }

                var identity = new ClaimsIdentity(new[] { 
            
                    new Claim(ClaimTypes.Name,  name),
                    new Claim(ClaimTypes.Email, Model.Email)
            
                }, DefaultAuthenticationTypes.ApplicationCookie);

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;
                authManager.SignIn(identity);

                return RedirectToAction("Index", "Home");

            }
            else
            {
                //Show validation
                ModelState.AddModelError("", "Invalid UserName or Password");

            }

            return View(Model);

        }

        public ActionResult Register()
        {
            var registerViewModel = new RegisterViewModel();
            return View(registerViewModel);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            

            if (ModelState.IsValid)
            {
                

                    var vendorRep = new VendorRepository();
                    var vendor = vendorRep.GetByName(model.Vendor);

                    var salesRepresentativeRepository = new SalesRepresentativeRepository();

                    var salesRepresentative = new SalesRepresentative();
                    salesRepresentative.FirstName = model.FirstName;
                    salesRepresentative.LastName = model.LastName;
                    salesRepresentative.Profile = new Profile();
                    salesRepresentative.Profile.Username = model.Email;
                    salesRepresentative.Profile.Password = model.Password;
                    salesRepresentative.Profile.CreateDate = DateTime.Now;
                    salesRepresentative.Profile.ModifiedDate = DateTime.Now;
                    salesRepresentative.Profile.ProfileType = "Representative";


                    salesRepresentative.VendorSalesRepresentatives.Add(new VendorSalesRepresentative() { VendorId = vendor.VendorId, RepresentativeType = "Rep" });

                    //Create Vendor SalesRep
                   long salesRepId = salesRepresentativeRepository.Create(salesRepresentative);
                                


                var identity = new ClaimsIdentity(new[] { 
            
                        new Claim(ClaimTypes.Name,  model.FirstName+ " ," + model.LastName),
                        new Claim(ClaimTypes.Email, model.Email)
            
                    }, DefaultAuthenticationTypes.ApplicationCookie);

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;
                authManager.SignIn(identity);


                return RedirectToAction("Index", "Home");

            }

            return View(model);
        }
        
        public ActionResult CustomerRegister()
        {
            var registerViewModel = new RegisterViewModel();
            return View(registerViewModel);
        }

        [HttpPost]
        public ActionResult CustomerRegister(RegisterViewModel model)
        {
            

            if (ModelState.IsValid)
            {
              
                
                    //customer Data insertion logic.
                    var CustomerRepository = new CustomerRepository();
                    var customer = new Customer();

                    customer.FirstName = model.FirstName;
                    customer.LastName = model.LastName;
                    customer.SSN = model.Customer.SSN;
                    customer.Address = new Address();
                    customer.Address.AddressLine1 = model.Address.AddressLine1.ToString();
                    customer.Address.AddressLine2 = model.Address.AddressLine2;
                    customer.Address.City = model.Address.City;
                    customer.Address.State = model.Address.State;
                    customer.Address.Zipcode = model.Address.Zipcode;
                    customer.EmailAddress = model.Email;
                    customer.Phone = model.Customer.Phone;
                    customer.Profile = new Profile();
                    customer.Profile.Username = model.Email;
                    customer.Profile.Password = model.Password;
                    customer.Profile.CreateDate = DateTime.Now;
                    customer.Profile.ModifiedDate = DateTime.Now;
                    customer.Profile.ProfileType = "Customer";


                    long CustomerId = CustomerRepository.Create(customer);

                    


                var identity = new ClaimsIdentity(new[] { 
            
                        new Claim(ClaimTypes.Name,  model.FirstName+ " ," + model.LastName),
                        new Claim(ClaimTypes.Email, model.Email)
            
                    }, DefaultAuthenticationTypes.ApplicationCookie);

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;
                authManager.SignIn(identity);


                return RedirectToAction("Index", "Home");

            }

            return View(model);
        }
        // POST: /Security/LogOff
        [HttpPost]
        public ActionResult LogOff()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}