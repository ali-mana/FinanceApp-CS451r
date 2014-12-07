using FinancingApp.Model.DbFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancingApp.DataAcess.DBFirst
{
    public class ApplicationRepository
    {
        private FinancingAppEntities _context = null;


        public IList<Application> GetApplications()
        {
            using (_context = new FinancingAppEntities())
            {
                
                return _context.Applications.ToList();

            }

        }

       

        public long Create(Application application)
        {
            using (_context = new FinancingAppEntities())
            {
                try
                {
                    application.CreatedDate = DateTime.Now;
                    application.ModifiedDate = DateTime.Now;
                    _context.Entry(application).State = System.Data.Entity.EntityState.Added;
                    _context.SaveChanges();

                    return application.ApplicationId;
                }
                catch (DbEntityValidationException ex)
                {
                    
                    throw;
                }

            }
        }

        public bool Update(Application application)
        {
            using (_context = new FinancingAppEntities())
            {
                _context.Entry(application).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return true;

            }
        }

        public bool Delete(Application application)
        {
            using (_context = new FinancingAppEntities())
            {
                _context.Entry(application).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();

                return true;

            }
        }
    }
}
