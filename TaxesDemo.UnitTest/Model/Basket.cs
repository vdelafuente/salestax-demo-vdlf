using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaxesDemo.UnitTesting.Model
{
    public class Basket
    {
        public int BasketId { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
