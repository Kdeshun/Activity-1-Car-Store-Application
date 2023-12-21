using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarClassLibrary1
{
    public class Car
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int CarCondition { get; set; }


        public Car()
        {
            this.Year = 0000;
            this.Make = "no make initialized";
            this.Model = "no model initialized";
            this.Price = 0.00M;
            this.CarCondition = 0;
        }

        public Car(int year, string make, string model, decimal price, int condition)
        {
            Year = year;
            Make = make;
            Model = model;
            Price = price;
            CarCondition = condition;
        }




        override public string ToString()
        {
            string Condition = "";
            if (CarCondition == 0)
            {
                Condition = "in great condition";
            }
            if (CarCondition == 1)
            {
                Condition = "in good condition";
            }
            if (CarCondition == 2)
            {
                Condition = "in poor condition";
            }
            return "Year: " + Year + ", Make: " + Make + ", Model: " + Model + ", Price: $" + Price + ", " + Condition;


        }

    }
}
