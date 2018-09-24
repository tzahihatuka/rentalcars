using _01_BOL;
using _02_BLL;
using _03_UIL.Filter;
using _03_UIL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace _03_UIL.Controllers
{

    [AuthenticationFilter]
    public class OrderController : ApiController
    {
        // GET: api/Order

       
        [Authorize(Roles = "admin,worker,castomer")]
        [Route("api/GetUserOrdesrByUserName")]
        [HttpGet]
        public IHttpActionResult GetUserOrdesrByUserName(string userName)
        {
            List<OrderModel> value = GetOrdersFilter.GetUserOrdesrByUserName(userName);
            return Ok(value);
        }
       
        [Authorize(Roles = "admin,worker,castomer")]
        [Route("api/GetUserOrdesrByidNumber")]
        [HttpGet]
        public IHttpActionResult GetUserOrdesrByidNumber(string idNumber)
        {
            List<OrderModel> value = GetOrdersFilter.GetUserOrdesrByidNumber(idNumber);
            return Ok(value);
        }

        [Authorize(Roles = "admin,worker,castomer")]
        [Route("api/GetListOrderByDate")]
        [HttpGet]
        public IHttpActionResult GetOrderByDate(DateTime start, DateTime end)
        {
            List<int> value = RentOrder.GetListOrderByDate(start, end);
            return Ok(value);
        }

        // POST: api/CarType

        public IHttpActionResult Post([FromBody]OrderModel order)
        {
            OrderModel value = GetOrdersFilter.PostOrders(order);
            return Ok(value);
        }

        // PUT: api/CarType/5

        [Authorize(Roles = "admin")]
        public IHttpActionResult Put([FromBody] OrderModel order)
        {
            BOLOrder RetrievedOrder = GetOrdersFilter.updateOrder(order);
            return Ok(RetrievedOrder);
        }

        [Authorize(Roles = "admin,worker")]
        [Route("api/returnCar")]
        [HttpPut]
        public IHttpActionResult returnCar([FromBody] OrderModel order)
        {
            BOLOrder RetrievedOrder = GetOrdersFilter.RetrieveOrder(order);
            BOLOrder getOrder = RentOrder.UpDataTo_db(RetrievedOrder);
            var a = (getOrder.ActualReturnDate.Value - getOrder.StartDate.Date).TotalDays;
            int CarsTypeID = RentCarsInVehicleInventory.GetCarsTypeID(getOrder.VehiclesID);
            decimal carPriceForDay = RentTypeOfCars.getDaylyCost(CarsTypeID);
            return Ok(carPriceForDay);
        }

        // DELETE: api/CarType/5

        [Authorize(Roles = "admin")]
        public IHttpActionResult Delete(string username, int carNumber,DateTime start)
        {
            var RetrievedOrder = GetOrdersFilter.RetrieveOrder(username, carNumber, start);
            RentOrder.deleteFrom_db(RetrievedOrder.UserID, RetrievedOrder.VehiclesID, RetrievedOrder.StartDate);
            return Ok();
        }
    }
}
