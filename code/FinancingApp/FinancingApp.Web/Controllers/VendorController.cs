using FinancingApp.DataAcess.DBFirst;
using FinancingApp.Model.DbFirst;
using FinancingApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancingApp.Web.Controllers
{
    public class VendorController : Controller
    {
        // GET: Vendor
        public ActionResult Index()
        {
            var viewModel = new VendorIndexViewModel();
            var vRepository = new VendorRepository();
            viewModel.Vendors = vRepository.GetVendors();

            return View(viewModel);
        }

        //GET: Vendor/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Vendor model)
        {
            var vRepository = new VendorRepository();
            vRepository.Create(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var vRepository = new VendorRepository();
            var vendor = vRepository.GetById(id);
            return View(vendor);
        }

        [HttpPost]
        public ActionResult Edit(Vendor model)
        {
            model.AddressId = model.Address.AddressId;
            var vRepository = new VendorRepository();
            vRepository.Update(model);

            return RedirectToAction("Index");
        }
    }
}