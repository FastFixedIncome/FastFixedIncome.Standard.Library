using System;
using System.Collections.Generic;
using System.Text;

/*
 * Fast Fixed Income Library - Error Codes
 * Known error codes for calculation errors
 * Date: 7/17/2021
 * Author: Shravan Jambukesan <shravan@shravanj.com>
 */

namespace FastFixedIncome.Standard.Library.Models.Errors
{
    public static class ErrorCodes
    {
        public const int UnhandledException = 1000;
        public const int BadDates = 1001;
        public const int BadParValue = 10002;
        public const int BadCouponRate = 10003;
        public const int InvalidDecimalResultRounding = 10004;
        public const int BadCurrentPrice = 10005;
        public const int BadNumberOfYearsTillMaturity = 10006;
    }
}
