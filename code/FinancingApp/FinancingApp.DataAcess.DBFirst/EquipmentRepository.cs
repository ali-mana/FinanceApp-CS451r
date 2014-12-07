using FinancingApp.Model.DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancingApp.DataAcess.DBFirst
{
    public class EquipmentRepository
    {
        private FinancingAppEntities _context = null;

        public long Create(Equipment equipment)
        {
            using (_context = new FinancingAppEntities())
            {
                _context.Entry(equipment).State = System.Data.Entity.EntityState.Added;
                _context.SaveChanges();
                return equipment.EquipmentId;

            }

        }
        public bool Update(Equipment equipment)
        {
            using (_context = new FinancingAppEntities())
            {
                _context.Entry(equipment).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return true;

            }
        }
        public bool Delete(Equipment equipment)
        {
            using (_context = new FinancingAppEntities())
            {
                _context.Entry(equipment).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
        }
        public Equipment GetbyId(long id)
        {
            using (_context = new FinancingAppEntities())
            {
                var equipment = _context.Equipments.Include("Address").Where(c => c.EquipmentId == id).SingleOrDefault();
                return equipment;
            }
        }
    }
}
