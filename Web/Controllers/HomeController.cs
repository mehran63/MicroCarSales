using MicroCarSales.Repository;
using MicroCarSales.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroCarSales.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index() { return View(); }

        public ActionResult AddCar() { return View(); }

        public ActionResult CarList() { return View(); }

        public ActionResult AddImages() { return View(); }

        public ActionResult CarDetails(int id)
        {
            var model = new CarDetailsVM();

            var repository = new MicroCarSalesRepository();
            model.Car = repository.Car.Get(id);
            model.Dealer = repository.User.GetDealer(model.Car.DealerUserId);
            model.ImageFileNames = repository.Car.GetImageFileNames(id);

            return View(model);
        }


        public ActionResult AddUser()
        {
            var repository = new MicroCarSalesRepository();
            var id = repository.User.CreateNew();
            return Content(id.ToString());
        }

        public ActionResult AddDealer()
        {
            var repository = new MicroCarSalesRepository();
            var id = repository.User.CreateDealer();
            return Content(id.ToString());
        }
    }
}