using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxesDemo.UnitTesting
{
    public class Product
    {
        public bool Imported { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Taxable { get; set; }
    }
}
