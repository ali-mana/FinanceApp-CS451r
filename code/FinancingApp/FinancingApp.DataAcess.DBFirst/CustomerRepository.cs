using FinancingApp.Model.DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancingApp.DataAcess.DBFirst
{
    public class CustomerRepository
    {
        private FinancingAppEntities _context = null;
        public long Create(Customer customer)
        {
            using (_context = new FinancingAppEntities())
            {
                _context.Entry(customer).State = System.Data.Entity.EntityState.Added;
                _context.SaveChanges();
                return customer.CustomerId;

            }

        }
        public bool Update(Customer customer)
        {
            using (_context = new FinancingAppEntities())
            {
                _context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
        }
        public bool Delete(Customer customer)
        {
            using (_context = new FinancingAppEntities())
            {
                _context.Entry(customer).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
                return true;

            }
        }

        public Customer GetbyId(long id)
        {
            using (_context = new FinancingAppEntities())
            {
                var customer = _context.Customers.Include("Address").Where(c => c.CustomerId == id).SingleOrDefault();
                return customer;

            }
        }

        public Customer GetByProfileId(long id)
        {
            using (_context = new FinancingAppEntities())
            {
                var customer = _context.Customers.Where(c => c.ProfileId == id).SingleOrDefault();
                return customer;
            }
        }
        public Customer GetBySSN(string SSN)
        {
            using (_context = new FinancingAppEntities())
            {
                var customer = _context.Customers.Where(c => c.SSN == SSN).SingleOrDefault();
                return customer;
            }
        }
    }
}

