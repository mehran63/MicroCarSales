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
        public JsonDbCore DB { get; private set; }
        internal UserRepository(JsonDbCore db)
        {
            DB = db;
        }

        public Dealer GetDealer(int id)
        {
            var store = new JsonStore<Dealer>(DB);
            var list = new BiggyList<Dealer>(store);
            return list.FirstOrDefault(d => d.Id == id);
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

        public int CreateDealer()
        {
            var store = new JsonStore<Dealer>(DB);
            var list = new BiggyList<Dealer>(store);
            int lastId = list.OrderByDescending(u => u.Id).FirstOrDefault()?.Id ?? 0;
            int newId = lastId + 1;
            list.Add(new Dealer
            {
                Id = newId,
                Email = $"dealer{newId}@user.com",
                Password = $"{newId}@testd",
                ABN = 1234567890,
                ContactName = "Deal Deal",
                Phone = 456789123
            });
            return newId;
        }
    }
}
