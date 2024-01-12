using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreebitcoinClaimer.Services
{
    public static class FreebitcoinHelper
    {
        public static string ToFreeBitcoinNumber(this string value) => (double.Parse(value) / 100000000).ToString("0.00000000", CultureInfo.InvariantCulture);
    }
}
