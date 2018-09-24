using _01_BOL;
using _02_BLL;
using _03_UIL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_UIL.Filter
{
    public class GetOrdersFilter
    {
        public static List<OrderModel> GetListOrders()
        {
            List<BOLOrder> userorsers = RentOrder.GetUserFrom_db();
            try
            {
                List<OrderModel> returneduserorsers = new List<OrderModel>();


                foreach (var item in userorsers)
                {

                    returneduserorsers.Add(new OrderModel
                    {

                        StartDate = item.StartDate,
                        ReturnDate = item.ReturnDate,
                        UserName = RentUser.GetUserName(item.UserID),
                        VehicleNumber = RentCarsInVehicleInventory.GetVehicleNumber(item.VehiclesID),
                        ActualReturnDate = item.ActualReturnDate
                    });
                }
                return returneduserorsers;


            }
            catch { }
            return null;
        }

        public static List<OrderModel> GetUserOrdesrByUserName(string userName)
        {
            try
            {
                List<OrderModel> orderList = new List<OrderModel>();
                List<BOLOrder> orders = RentOrder.GetUsersOrdesrByUserName(userName);
                foreach (var item in orders)
                {

                    orderList.Add(new OrderModel
                    {

                        StartDate = item.StartDate,
                        ReturnDate = item.ReturnDate,
                        UserName = userName,
                        VehicleNumber = RentCarsInVehicleInventory.GetVehicleNumber(item.VehiclesID),
                        ActualReturnDate = item.ActualReturnDate
                    });
                }
                return orderList;
            }
            catch { return null; }
        }
        public static List<OrderModel> GetUserOrdesrByidNumber(string idNumber)
        {
            try {
            List<OrderModel> orderList = new List<OrderModel>();
            List<BOLOrder> orders = RentOrder.GetUsersOrdesrByidNumber(idNumber);
            foreach (var item in orders)
            {
                if (item.ActualReturnDate == null)
                {
                    orderList.Add(new OrderModel
                    {

                        StartDate = item.StartDate,
                        ReturnDate = item.ReturnDate,
                        UserName = RentUser.GetUserNume(idNumber),
                        VehicleNumber = RentCarsInVehicleInventory.GetVehicleNumber(item.VehiclesID),
                        ActualReturnDate = item.ActualReturnDate

                    });
                }
            }
            return orderList;
            }
            catch { return null; }
        }

        internal static BOLOrder updateOrder(OrderModel order)
        {
            try
            {
                return RentOrder.SaveUpDataTo_db(RetrieveOrder(order), order.oldStart);
            }
            catch { return null; }
        }

        internal static BOLOrder RetrieveOrder(string userName, int carNumber, DateTime start)
        {
            try
            {
                BOLOrder newOrder = new BOLOrder();

                newOrder.StartDate = start;
                newOrder.UserID = RentUser.GetUserid(userName);
                newOrder.VehiclesID = RentCarsInVehicleInventory.GetVehicleid(carNumber);
                    return newOrder;
            }
            catch { return null; }
        }

        public static OrderModel PostOrders(OrderModel Order)
        {
            try
            {
                BOLOrder newOrder = new BOLOrder();

                newOrder.StartDate = Order.StartDate;
                newOrder.ReturnDate = Order.ReturnDate;
                newOrder.UserID = RentUser.GetUserid(Order.UserName);
                newOrder.VehiclesID = RentCarsInVehicleInventory.GetVehicleid(Order.VehicleNumber);
                newOrder.ActualReturnDate = Order.ActualReturnDate;

                if (RentOrder.AddBranchTo_db(newOrder)) { 
                return Order;
                }
                return null;
            }
            catch { return null; }
        }

        public static BOLOrder RetrieveOrder(OrderModel orderModel)
        {
            try
            {
                BOLOrder newOrder = new BOLOrder();

                newOrder.StartDate = orderModel.StartDate;
                newOrder.ReturnDate = orderModel.ReturnDate;
                newOrder.UserID = RentUser.GetUserid(orderModel.UserName);
                newOrder.VehiclesID = RentCarsInVehicleInventory.GetVehicleid(orderModel.VehicleNumber);
                newOrder.ActualReturnDate = orderModel.ActualReturnDate;

                return newOrder;
            }
            catch { return null; }
        }
        public static List<BOLOrder> RetrievelistOrder(List<OrderModel> orderModel)
        {
            try
            {
                List<BOLOrder> newOrder = new List<BOLOrder>();
                foreach (var item in orderModel)
                {
                    newOrder.Add(new BOLOrder
                    {
                        StartDate = item.StartDate,
                        ReturnDate = item.ReturnDate,
                        UserID = RentUser.GetUserid(item.UserName),
                        VehiclesID = RentCarsInVehicleInventory.GetVehicleid(item.VehicleNumber),
                        ActualReturnDate = item.ActualReturnDate
                    });
                }
                return newOrder;
            }
            catch { return null; }
        }
    }
}