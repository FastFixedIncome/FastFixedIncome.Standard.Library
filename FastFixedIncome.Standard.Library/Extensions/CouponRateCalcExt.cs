using System;
using System.Collections.Generic;
using System.Text;
using FastFixedIncome.Standard.Library.Models;

namespace FastFixedIncome.Standard.Library.Extensions
{
    public static class CouponRateCalcExt
    {
        public static decimal GetCouponRateUsing(decimal couponRate, CouponPaymentFrequency couponPaymentFrequency, bool useThirtyDayCount)
        {
            decimal adjustedCouponRate = 0;

            switch (couponPaymentFrequency)
            {
                case CouponPaymentFrequency.Annual:
                    adjustedCouponRate = couponRate;
                    break;
                case CouponPaymentFrequency.SemiAnnual:
                    adjustedCouponRate = couponRate / 2;
                    break;
                case CouponPaymentFrequency.Quarterly:
                    adjustedCouponRate = couponRate / 4;
                    break;
                case CouponPaymentFrequency.Monthly:
                    adjustedCouponRate = couponRate / 12;
                    break;
                case CouponPaymentFrequency.Weekly:
                    adjustedCouponRate = couponRate / 52;
                    break;
                case CouponPaymentFrequency.Daily:
                    if (useThirtyDayCount)
                    {
                        adjustedCouponRate = couponRate / 360;
                    }
                    else
                    {
                        adjustedCouponRate = couponRate / 365;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(couponPaymentFrequency), couponPaymentFrequency, null);
            }

            return adjustedCouponRate;
        }
    }
}
