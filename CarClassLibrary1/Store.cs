using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarClassLibrary1
{
    public class Store
    {
        public List<Car> CarList { get; set; }
        public List<Car> ShopList { get; set; }

        public Store()
        {
            CarList = new List<Car>();
            ShopList = new List<Car>();

        }

        public decimal Checkout()
        {
            decimal totalCost = 0;

            foreach (var c in ShopList)
            {
                totalCost += c.Price;
            }

            ShopList.Clear();
            return totalCost;
        }
    }
}
