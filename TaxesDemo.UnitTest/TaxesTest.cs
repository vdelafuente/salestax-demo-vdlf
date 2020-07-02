using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using TaxesDemo.UnitTest.Util;
using TaxesDemo.UnitTesting.Model;

namespace TaxesDemo.UnitTest
{
    [TestClass]
    public class TaxesTest
    {
        [TestMethod]
        public void CalculateTotalBasket1()
        {
            var result = CalculateBasket(1);
            Assert.AreEqual(Convert.ToDecimal(29.83), result);
        }

        [TestMethod]
        public void CalculateTotalBasket2()
        {
            var result = CalculateBasket(2);
            Assert.AreEqual(Convert.ToDecimal(65.15), result);
        }

        [TestMethod]
        public void CalculateTotalBasket3()
        {
            var result = CalculateBasket(3);
            Assert.AreEqual(Convert.ToDecimal(74.68), result);
        }

        [TestMethod]
        public void CalculateTaxesBasket1()
        {
            var result = CalculateTaxes(1);
            Assert.AreEqual(Convert.ToDecimal(1.5), result);
        }

        [TestMethod]
        public void CalculateTaxesBasket2()
        {
            var result = CalculateTaxes(2);
            Assert.AreEqual(Convert.ToDecimal(7.65), result);
        }

        [TestMethod]
        public void CalculateTaxesBasket3()
        {
            var result = CalculateTaxes(3);
            Assert.AreEqual(Convert.ToDecimal(6.7), result);
        }


        private decimal CalculateBasket(int basketId)
        {
            decimal totalPrice = 0;
            using (var sr = new StreamReader($"basket.json"))
            {
                var json = sr.ReadToEnd();
                var baskets = JsonConvert.DeserializeObject<List<Basket>>(json);
                var basket = baskets.FirstOrDefault(b => b.BasketId == basketId);

                decimal totalTaxes = 0;
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
                }

                totalPrice = productSum + totalTaxes;
            }
            return totalPrice;
        }

        private decimal CalculateTaxes(int basketId)
        {
            decimal totalTaxes = 0;
            using (var sr = new StreamReader($"basket.json"))
            {
                var json = sr.ReadToEnd();
                var baskets = JsonConvert.DeserializeObject<List<Basket>>(json);
                var basket = baskets.FirstOrDefault(b => b.BasketId == basketId);

                foreach (var product in basket.Products)
                {
                    decimal tax = 0;
                    if (product.Taxable)
                        tax += Taxes.GetRegularTax(product.Price);
                    if (product.Imported)
                        tax += Taxes.GetImportationTax(product.Price);
                    decimal taxProduct = Calculate.Round(tax);
                    totalTaxes += taxProduct;
                }
            }
            return totalTaxes;
        }
    }

}
