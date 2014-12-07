

using FinancingApp.Model.DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancingApp.DataAcess.DBFirst
{
    public class VendorRepository
    {
        private FinancingAppEntities _context = null;
        public long Create(Vendor vendor)
        {

            using (_context = new FinancingAppEntities())
            {
                _context.Vendors.Add(vendor);
 
                _context.SaveChanges();

                return vendor.VendorId;
            }

        }

        public bool Update(Vendor vendor)
        {
            using (_context = new FinancingAppEntities())
            {
                _context.Entry(vendor).State = System.Data.Entity.EntityState.Modified;
                _context.Entry(vendor.Address).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
        }

        public IList<Vendor> GetVendors()
        {

            using (_context = new FinancingAppEntities())
            {
                var vendors = _context.Vendors.Include("Address").ToList();
                return vendors;
            }
        }


        public Vendor GetById(long id)
        {

            using (_context = new FinancingAppEntities())
            {


                var customer = _context.Vendors.Include("Address").Where(c => c.VendorId == id).SingleOrDefault();
                
                return customer;
            }
        }

        public Vendor GetByName(string name)
        {

            using (_context = new FinancingAppEntities())
            {
                var customer = _context.Vendors.Where(c => c.Name == name).FirstOrDefault();
                return customer;
            }
        }

        public bool Delete(Vendor vendor)
        {
            using (_context = new FinancingAppEntities())
            {
                _context.Entry(vendor).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
        }

        public IList<Vendor> GetSalesRepVendors(long SalesRepID)
        {

            using (_context = new FinancingAppEntities())
            {
                var vendors = _context.VendorSalesRepresentatives.Where(c => c.SalesRepresentativeId == SalesRepID).Select(x => x.Vendor).ToList();
                return vendors;
            }
        }
    }
}
