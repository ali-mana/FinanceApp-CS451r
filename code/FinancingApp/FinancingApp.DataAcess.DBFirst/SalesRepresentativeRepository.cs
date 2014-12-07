using FinancingApp.Model.DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancingApp.DataAcess.DBFirst
{
    public class SalesRepresentativeRepository
    {
        private FinancingAppEntities _context = null;
        public long Create(SalesRepresentative salesrepresentative)
        {
            using (_context = new FinancingAppEntities())
            {
                _context.Entry(salesrepresentative).State = System.Data.Entity.EntityState.Added;
                _context.SaveChanges();
                return salesrepresentative.SalesRepresentativeId;
            }
        }
        public bool Update(SalesRepresentative salesrepresentative)
        {
            using (_context = new FinancingAppEntities())
            {
                _context.Entry(salesrepresentative).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
        }
        public bool Delete(SalesRepresentative salesrepresentative)
        {
            using (_context = new FinancingAppEntities())
            {
                _context.Entry(salesrepresentative).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
                return true;

            }
        }
        public SalesRepresentative GetbyId(long id)
        {
            using (_context = new FinancingAppEntities())
            {
                var salesrepresentative = _context.SalesRepresentatives.Where(c => c.SalesRepresentativeId == id).SingleOrDefault();
                return salesrepresentative;
            }
        }

        public SalesRepresentative GetByProfileId(long id)
        {
            using (_context = new FinancingAppEntities())
            {
                var salesrepresentative = _context.SalesRepresentatives.Where(c => c.ProfileId == id).SingleOrDefault();
                return salesrepresentative;
            }
        }

        public SalesRepresentative GetByProfileUsername(string username)
        {
            using (_context = new FinancingAppEntities())
            {
                var salesrepresentative = _context.SalesRepresentatives.Include("VendorSalesRepresentatives").Where(c => c.Profile.Username == username).SingleOrDefault();
                return salesrepresentative;
            }
        }
    }
}
