using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxesDemo.Util
{
    public class Taxes
    {
        private static readonly decimal regularTax = new decimal(0.1);
        private static readonly decimal importationTax = new decimal(0.05);

        public static decimal GetRegularTax(decimal price)
        {
            return price * regularTax;
        }

        public static decimal GetImportationTax(decimal price)
        {
            return price * importationTax;
        }
    }
}
