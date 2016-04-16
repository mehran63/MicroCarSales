using Biggy.Core;
using Biggy.Data.Json;
using MicroCarSales.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MicroCarSales.Repository
{
    public class CarRepository
    {
        public JsonDbCore DB { get;private set; }
        internal CarRepository(JsonDbCore db)
        {
            DB = db;
        }

        public int Add(Car car)
        {
            var store = new JsonStore<Car>(DB);
            var list = new BiggyList<Car>(store);
            int lastId = list.OrderByDescending(u => u.Id).FirstOrDefault()?.Id ?? 0;
            car.Id = lastId + 1;
            list.Add(car);
            return car.Id;
        }
    }
}
