using System;
using System.Collections.Generic;
using System.Text;

/*
 * Fast Fixed Income Library - Generic Coupon
 * Entity for encapsulating generic bond coupon details
 * Date: 7/17/2021
 * Author: Shravan Jambukesan <shravan@shravanj.com>
 */

namespace FastFixedIncome.Standard.Library.Models.Bonds
{
    public class GenericCoupon
    {
        public double CouponPayment { get; set; }

        public double YieldToMaturity { get; set; }

        public int NumberOfPeriods { get; set; }
    }
}
