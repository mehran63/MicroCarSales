using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCarSales.DataModel
{
    public class Car
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public short Year { get; set; }

        public int Price { get; set; }

        public int DealerUserId { get; set; }

        public string Description { get; set; }
    }
}
