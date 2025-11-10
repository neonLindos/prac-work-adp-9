using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac_work_adp_9.task1.HotelSystem
{
    public class TaxiService
    {
        public void OrderTaxi(string destination)
        {
            Console.WriteLine($"Taxi ordered to destination: {destination}. ETA 10 minutes.");
        }
    }
}
