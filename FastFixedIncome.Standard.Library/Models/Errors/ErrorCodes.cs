using System;
using System.Collections.Generic;
using System.Text;

namespace FastFixedIncome.Standard.Library.Models.Errors
{
    public static class ErrorCodes
    {
        public const int UnhandledException = 1000;
        public const int BadDates = 1001;
        public const int BadParValue = 10002;
        public const int BadCouponRate = 10003;
        public const int InvalidDecimalResultRounding = 10004;
    }
}
