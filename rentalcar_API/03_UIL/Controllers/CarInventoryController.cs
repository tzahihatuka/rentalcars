using _01_BOL;
using _02_BLL;
using _03_UIL.Filter;
using _03_UIL.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;

namespace _03_UIL.Controllers
{

    public class CarInventoryController : ApiController
    {
        // GET: api/CarInventory
        public IHttpActionResult Get(int from, int to)
        {
            var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);

            List<BOLCarInventory> value = RentCarsInVehicleInventory.GetCarFrom_db();
            foreach (var item in value)
            {
                item.VehiclePic = baseUrl + @"/image/" + item.VehiclePic;
            }
            List<CarInventoryModel> carList = GetCarInventoryFilter.ListRetrieveCarInventory(value, from, to);
            return Ok(carList);
        }

        public IHttpActionResult Get(int carNumber)
        {
            var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);

            BOLCarInventory value = RentCarsInVehicleInventory.GetCarFrom_db(carNumber);
            if (value != null)
            {
                value.VehiclePic = baseUrl + @"/image/" + value.VehiclePic;

                CarInventoryModel carList = GetCarInventoryFilter.ReturnCarInventory(value);
                return Ok(carList);
            }
            return null;
            
        }


        public IHttpActionResult Get(string orderlist)
        {
            var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            JObject json = JObject.Parse(orderlist);
            List<OrderModel> orderList=new List<OrderModel>();
            foreach (var item in json)
            {
                    orderList = new JavaScriptSerializer().Deserialize<List<OrderModel>>(item.Value.ToString());
            }
             List<BOLOrder> convertedOrderList= GetOrdersFilter.RetrievelistOrder(orderList);

              List<BOLCarInventory> value = RentCarsInVehicleInventory.GetCarFrom_db(convertedOrderList);
              foreach (var item in value)
              {
                  item.VehiclePic = baseUrl + @"/image/" + item.VehiclePic;
              }


             List<CarInventoryModel> carList = GetCarInventoryFilter.ListRetrieveCarInventory1(value, convertedOrderList);
            return Ok(carList);
        }

        // GET: api/CarInventory
        [Route("api/FilteredCars")]
        [HttpGet]
        public IHttpActionResult GetFilteredCars(string Company, string Gear, string Model, string openText, DateTime? Year)
        {
            var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);

            List<BOLCarInventory> value = RentCarsInVehicleInventory.GetCarFrom_db();
            foreach (var item in value)
            {
                item.VehiclePic = baseUrl + @"/image/" + item.VehiclePic;
            }
            List<CarInventoryModel> carList = GetCarInventoryFilter.ListRetrieveFilteredCarInventory(value, Company, Gear, Model, openText, Year);
            return Ok(carList);
        }


        // POST: api/CarInventory
        [AuthenticationFilter]
        [Authorize(Roles = "admin")]
        public IHttpActionResult Post([FromBody]CarInventoryModel newCarType)
        {
            BOLCarInventory RetrievedCarInventory = GetCarInventoryFilter.RetrieveCarInventory(newCarType);
            BOLCarInventory add= RentCarsInVehicleInventory.AddCarTo_db(RetrievedCarInventory);
            return Ok(add);
        }

        // PUT: api/CarInventory
        [AuthenticationFilter]
        [Authorize(Roles = "admin")]
        public IHttpActionResult Put([FromBody] List<CarInventoryModel> Car)
        {
            BOLCarInventory RetrievedCarInventory0 = GetCarInventoryFilter.RetrieveCarInventory(Car[0]);
            BOLCarInventory RetrievedCarInventory1 = GetCarInventoryFilter.RetrieveCarInventory(Car[1]);
            RentCarsInVehicleInventory.UpDataTo_db(RetrievedCarInventory0, RetrievedCarInventory1);
            return Ok();
        }

        // DELETE: api/CarInventory/5
        [AuthenticationFilter]
        [Authorize(Roles = "admin")]
        public IHttpActionResult Delete(int CarNumber )
        {
            string a = RentCarsInVehicleInventory.deleteFrom_db(CarNumber);
            return Ok(a);
        }
    }
}
