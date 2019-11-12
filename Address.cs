using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Address
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool CheckIfDatesOverlap(Address address1, Address address2)
        {
            if(address1!=null && address2!=null)
            {
                if (address1.EndDate > address2.EndDate)
                    CheckIfDatesOverlap(address2, address1);
                if ((address2.EndDate - address2.StartDate).Days > (address2.EndDate - address1.EndDate).Days)
                    return true;
            }
            return false;
        }
}
    public class Program
    {




        //public static void Main()
        //{
        //    Address address1 = new Address
        //    {
        //        StartDate = new DateTime(2019, 02, 14, 2, 30, 20),
        //        EndDate = new DateTime(2019, 02, 15, 2, 30, 20)
        //    };
        //    Address address2 = new Address
        //    {
        //        StartDate = new DateTime(2019, 02, 14, 2, 30, 20),
        //        EndDate = new DateTime(2019, 02, 15, 2, 30, 20)
        //    };

        //    var val = formatter.Format(DateTime.Now.AddDays(-1), DateTime.Now);
        //    if (address1.CheckIfDatesOverlap(address1, address2))
        //        Console.WriteLine("True");
        //}
    }

}
