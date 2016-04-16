﻿using MicroCarSales.Repository;
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