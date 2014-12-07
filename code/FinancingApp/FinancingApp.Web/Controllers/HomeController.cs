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
   
    public class HomeController : Controller
    {
   
        
        public ActionResult Index()
        {
            
          ViewBag.Title = "Home Page";
           
                return View();
            var applicationRep = new ApplicationRepository();

            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            var email = authManager.User.FindFirst(ClaimTypes.Email).Value.ToString();

            var salesRepresentativeRepository = new SalesRepresentativeRepository();
            var salesRep = salesRepresentativeRepository.GetByProfileUsername(email);


            var SalesRepresentativeId = salesRep.SalesRepresentativeId;
            

           /* var model = new ApplicationCreateViewModel();


        //    var applications = applicationRep.GetApplications();

            var applicationcount = new HomeModel();

            
            var applications = applicationRep.GetApplications();

            var Count = applications.Where(c => c.SalesRepresentativeId == SalesRepresentativeId).GroupBy(c => c.VendorId).Select(c => new { VendorId = c.Key, count = c.Count() }).ToList();

          //  applicationcount. = Count.ToList();
            
            
            return View(applicationcount);*/

        }
       

        
        public ActionResult About()
        {
            

            return View();
        }
        
    }
}