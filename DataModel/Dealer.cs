using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCarSales.DataModel
{
    public class Dealer : User
    {
        public int ABN { get; set; }

        public int Phone { get; set; }

        public string ContactName { get; set; }
    }
}
