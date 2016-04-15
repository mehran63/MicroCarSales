using Biggy.Data.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MicroCarSales.Repository
{
    public class MicroCarSalesRepository
    {
        private JsonDbCore _db = new JsonDbCore(HttpRuntime.AppDomainAppPath + "/App_Data", "DB");

        public UserRepository User { get; set; }
        public MicroCarSalesRepository()
        {
            User = new UserRepository(_db);
        }
    }
}
