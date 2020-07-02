using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using TaxesDemo.Model;
using TaxesDemo.Util;

namespace TaxesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            UiMessages.DisplayWelcomeMessage();
            using (var sr = new StreamReader($"basket.json"))
            {
                var json = sr.ReadToEnd();
                var baskets = JsonConvert.DeserializeObject<List<Basket>>(json);

                foreach (var basket in baskets)
                {
                    UiMessages.DisplayBasketHeader(basket.BasketId.ToString());

                    decimal totalTaxes = 0;
                    decimal totalPrice = 0;
                    decimal productSum = 0;

                    foreach (var product in basket.Products)
                    {
                        decimal tax = 0;
                        productSum += product.Price;

                        if (product.Taxable)
                            tax += Taxes.GetRegularTax(product.Price);

                        if (product.Imported)
                            tax += Taxes.GetImportationTax(product.Price);
                        decimal taxProduct = Calculate.Round(tax);
                        totalTaxes += taxProduct;
                        Console.WriteLine($"{product.Name}: ${product.Price} Tax: ${taxProduct}");
                    }

                    totalPrice = productSum + totalTaxes;

                    UiMessages.DisplayBasketTotal(totalTaxes, totalPrice);
                    UiMessages.ReadNextBasket();
                }
            }
        }
    }
}
