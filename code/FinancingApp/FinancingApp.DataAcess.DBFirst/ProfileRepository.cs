using FinancingApp.Model.DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancingApp.DataAcess.DBFirst
{
    public class ProfileRepository
    {
        private FinancingAppEntities _context = null;

        public IList<Profile> GetProfiles()
        {

            using (_context = new FinancingAppEntities())
            {
                var profiles = _context.Profiles.ToList();
                return profiles;
            }
        }

        public Profile GetByUsername(string name)
        {

            using (_context = new FinancingAppEntities())
            {

                var customer = _context.Profiles.Where(c => c.Username == name).SingleOrDefault();

                return customer;
            }
        }
    }
}

