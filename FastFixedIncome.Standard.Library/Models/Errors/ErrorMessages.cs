using System;
using System.Collections.Generic;
using System.Text;

namespace FastFixedIncome.Standard.Library.Models.Errors
{
    public static class ErrorMessages
    {
        public const string InvalidRequestDates =
            "Request date must be before the maturity date and after the first coupon payment date";

        public const string BadParValue = "Par value must be greater than 0";

        public const string BadCouponRate = "Coupon rate must be greater than 0";

        public const string BadRoundingSetting = "Decimal result rounding must be greater than 0";
    }
}
