using System;
using System.Collections.Generic;
using System.Text;

namespace FastFixedIncome.Standard.Library.Extensions
{
    public static class MathExt
    {
        public static double ToDouble(this decimal decimalValue)
        {
            return Convert.ToDouble(decimalValue);
        }

        public static double ToDoubleWithRounding(this decimal decimalValue, int numberOfDecimalPoints)
        {
            decimalValue = decimal.Round(decimalValue, numberOfDecimalPoints);

            return Convert.ToDouble(decimalValue);
        }
    }
}
