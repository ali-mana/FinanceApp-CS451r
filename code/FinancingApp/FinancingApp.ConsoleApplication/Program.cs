
using FinancingApp.DataAcess.DBFirst;
using FinancingApp.Model.DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancingApp.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            var vendorRepository = new VendorRepository();

            //var vendor2 = vendorRepository.GetById(2);

           // vendorRepository.Delete(vendor2);

            //vendor2.Name = "BMW";

            //vendorRepository.Update(vendor2);

            var vendor = new Vendor();
            vendor.Name = "Audi";
            vendor.Address = new Address();
            vendor.Address.AddressLine1 = "12 Main st";
            vendor.Address.City = "Houston";
            //vendor.Address.State = "TX";
            //vendor.Address.Zipcode = "34344";

            
            long id = vendorRepository.Create(vendor);

           

        }
    }
}
