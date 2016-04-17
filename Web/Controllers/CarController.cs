using MicroCarSales.DataModel;
using MicroCarSales.Repository;
using MicroCarSales.Web.ServiceContract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;

namespace MicroCarSales.Web.Controllers
{
    [RoutePrefix("api/cars")]
    public class CarController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Car> List()
        {
            var repository = new MicroCarSalesRepository();
            var cars = repository.Car.GetList();
            return cars;
        }

        [Route("")]
        public IHttpActionResult Post(Car car)
        {
            car.DealerUserId = 1;//TODO: replace 1 with current dealer user id

            var repository = new MicroCarSalesRepository();

            repository.Car.Add(car);

            return Ok(car.Id);
        }

        [HttpPost()]
        [Route("{id:int}/images")]
        public string UploadImages(int id)
        {
            string path = HostingEnvironment.MapPath($"~/CarImages/Car{id}/");
            Directory.CreateDirectory(path);

            System.Web.HttpFileCollection httpFileCollection = System.Web.HttpContext.Current.Request.Files;

            for (int i = 0; i <= httpFileCollection.Count - 1; i++)
            {
                System.Web.HttpPostedFile hpf = httpFileCollection[i];

                if (hpf.ContentLength > 0)
                {
                    hpf.SaveAs(path + Path.GetFileName(hpf.FileName));
                }
            }

            return httpFileCollection.Count + " Files Uploaded Successfully";
        }

    }
}
