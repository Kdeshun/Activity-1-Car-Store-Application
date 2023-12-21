using CarClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            Store s = new Store();

            Console.WriteLine("Welcome, please create an inventory of your cars, add them to your shopping cart, and finally checkout with the shopping cart to get the total value of your entire cart.");

            int action = chooseAction();
            while (action != 0 && action > -1 && action < 4)
            {

                Console.WriteLine("you chose " + action);
                switch (action)
                {
                    //add new car to inventory
                    case 1:
                        Console.WriteLine("You Chose to add a new Car");

                        int carYear = 0;
                        string carMake = "";
                        string carModel = "";
                        Decimal carPrice = 0;
                        int carCondition = 0;

                        Console.WriteLine("What year is the car? 1908-Current");
                        carYear = int.Parse(Console.ReadLine());

                        Console.WriteLine("What is the make of the car? Ford, Gm, Honda etc.");
                        carMake = Console.ReadLine();

                        Console.WriteLine("What is the model of the car? Mustang, Express, Civic etc.");
                        carModel = Console.ReadLine();

                        Console.WriteLine("What is the price of the car?");
                        carPrice = int.Parse(Console.ReadLine());

                        Console.WriteLine("what condition is the car in? (1) for Great Condition (2) for Good Condition (3) for Poor Condition");
                        int conditionCheck = int.Parse(Console.ReadLine()) - 1;

                        while (conditionCheck > 3 && conditionCheck < 0)
                        {
                            Console.WriteLine("Error, please enter value between 1 and 3.");
                            conditionCheck = int.Parse(Console.ReadLine()) - 1;
                        }
                        carCondition = conditionCheck;

                        Car newCar = new Car(carYear, carMake, carModel, carPrice, carCondition);
                        s.CarList.Add(newCar);

                        printInventory(s);
                        break;

                    //add car to cart
                    case 2:
                        if (s.CarList.Count > 0)
                        {
                            Console.WriteLine("You Chose to add a Car to your cart.");
                            printInventory(s);
                            Console.WriteLine("Which item would you like to buy?");
                            int carChosen = int.Parse(Console.ReadLine());
                            s.ShopList.Add(s.CarList[carChosen]);

                            printShoppingCart(s);
                        }

                        else
                        {
                            Console.WriteLine("Error, please add cars to inventory first:");

                        }
                        break;

                    case 3:
                        printShoppingCart(s);
                        Console.WriteLine("the total cost of your items is: " + s.Checkout());
                        break;
                    default:
                        break;
                }








                action = chooseAction();
            }


        }

        private static void printShoppingCart(Store s)
        {
            Console.WriteLine("Cars you have chosen to buy: ");
            for (int i = 0; i < s.ShopList.Count; i++)
            {
                Console.WriteLine("Car #: " + i + ", " + s.ShopList[i]);
            }
        }

        private static void printInventory(Store s)
        {
            for (int i = 0; i < s.CarList.Count; i++)
            {
                Console.WriteLine("Car #: " + i + ", " + s.CarList[i]);
            }
        }

        static public int chooseAction()
        {
            int choice = 0;
            Console.WriteLine("(0) to quit (1) to add new car to inventory (2) add car to cart (3) to checkout");

            try
            {
                choice = int.Parse(Console.ReadLine());

            }
            catch (Exception e)
            {
                Console.WriteLine("Error, please enter a number.");
                choice = -1;
            }
            return choice;
        }

    }
}
