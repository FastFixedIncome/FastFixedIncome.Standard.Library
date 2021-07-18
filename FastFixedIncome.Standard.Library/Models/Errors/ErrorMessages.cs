using System;
using System.Collections.Generic;
using System.Text;

/*
 * Fast Fixed Income Library - Error Messages
 * Known error messages for calculation errors
 * Date: 7/17/2021
 * Author: Shravan Jambukesan <shravan@shravanj.com>
 */

namespace FastFixedIncome.Standard.Library.Models.Errors
{
    public static class ErrorMessages
    {
        public const string InvalidRequestDates =
            "Request date must be before the maturity date and after the first coupon payment date";

        public const string BadParValue = "Par value must be greater than 0";

        public const string BadCouponRate = "Coupon rate must be greater than 0";

        public const string BadRoundingSetting = "Decimal result rounding must be greater than 0";

        public const string BadCurrentPrice = "Current price must be greater than 0";

        public const string BadNumberOfYearsTillMaturity = "Number of years till maturiy must be greater than 0";
    }
}
