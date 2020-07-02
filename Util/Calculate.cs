using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxesDemo.Util
{
    public class Calculate
    {
        public static decimal Round(decimal value)
        {
            var ceiling = Math.Ceiling(value * 20);
            return ceiling == 0 ? 0 : ceiling / 20;
        }
    }
}
