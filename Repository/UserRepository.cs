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
    public class UserRepository
    {
        public JsonDbCore DB { get;private set; }
        internal UserRepository(JsonDbCore db)
        {
            DB = db;
        }

        public int CreateNew()
        {
            var store = new JsonStore<User>(DB);
            var list = new BiggyList<User>(store);
            int lastId = list.OrderByDescending(u => u.Id).FirstOrDefault()?.Id ?? 0;
            int newId = lastId + 1;
            list.Add(new User { Id = newId, Email = $"user{newId}@user.com", Password = $"{newId}@testp" });
            return newId;
        }
    }
}
