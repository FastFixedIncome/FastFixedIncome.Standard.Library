using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using FastFixedIncome.Standard.Library.Models.Bonds;

/*
 * Fast Fixed Income Library - Math Calculation Extensions
 * Extension methods for shared mathematical calculations that apply to several fixed income security types
 * Date: 7/17/2021
 * Author: Shravan Jambukesan <shravan@shravanj.com>
 */

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

        public static double SumCouponPayments(this IEnumerable<GenericCoupon> coupons)
        {
            var payments = new List<double>();

            foreach (var coupon in coupons)
            {
                var payment = coupon.CouponPayment /
                              Math.Pow(1.0 + coupon.YieldToMaturity, Convert.ToDouble(coupon.NumberOfPeriods));
                payments.Add(payment);
            }

            return payments.Sum();
        }

        public static double CalculateFaceValueUsing(this GenericFaceValue faceValue)
        {
            return faceValue.FaceValue / Math.Pow((1.0 + faceValue.YieldToMaturity), faceValue.TimeToMaturity);
        }
    }
}
