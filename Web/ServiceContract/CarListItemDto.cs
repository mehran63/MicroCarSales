using MicroCarSales.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroCarSales.Web.ServiceContract
{
    public class CarListItemDto
    {
        public Car Car { get; set; }

        public Dealer Dealer { get; set; }
    }
}