using System;
using _01_BOL;
using _00_DAL;
using System.Linq;
using System.Collections.Generic;

namespace _02_BLL
{
    internal class validateCarAvailable
    {
       
        internal static bool IsAvailable(BOLOrder order)
        {
            try
            {
                using (RentalcarsEntities1 ef = new RentalcarsEntities1())
                {
                    bool a = true;
                    List<Order> dbOrder = ef.Orders.Where(u => u.VehiclesID == order.VehiclesID && u.ActualReturnDate == null).ToList();
                    foreach (var item in dbOrder)
                    {
                        if (item.ReturnDate >= order.StartDate && item.StartDate <= order.StartDate)
                        {
                            a = false;
                        }
                    }
                    return a;
                }
            }
            catch { return false; }
        }
    }

}

