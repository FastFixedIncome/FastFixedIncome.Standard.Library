using System;
using System.Collections.Generic;
using System.Text;

namespace FastFixedIncome.Standard.Library.Models.Errors
{
    public static class ErrorMessages
    {
        public const string InvalidRequestDates =
            "Request date must be before the maturity date and after the first coupon payment date";
    }
}
