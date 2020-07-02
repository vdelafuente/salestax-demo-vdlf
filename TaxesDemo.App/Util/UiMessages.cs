using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Bson;

namespace TaxesDemo.Util
{
    public class UiMessages
    {
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Tax Calculator!!!");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
            Console.WriteLine("To proceed and read the first basket press ENTER :)");
            Console.ReadLine();
        }
        public static void ReadNextBasket()
        {
            Console.WriteLine();
            Console.WriteLine("To proceed and read the next basket press ENTER again ;)");
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void DisplayBasketHeader(string basketNumber)
        {
            Console.WriteLine($"Basket Output {basketNumber}");
            Console.WriteLine("------------------");
        }

        public static void DisplayBasketTotal(decimal totalTaxes, decimal totalPrice)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Sales Taxes: ${totalTaxes} Total: ${totalPrice}");
        }
    }
}
