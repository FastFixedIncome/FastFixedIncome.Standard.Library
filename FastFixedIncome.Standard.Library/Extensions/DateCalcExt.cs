using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using FastFixedIncome.Standard.Library.Models;

/*
 * Fast Fixed Income Library - Date Calculation Extensions
 * Extension methods for date calculations pertaining to accrual day counts, payment dates, and more
 * Date: 7/17/2021
 * Author: Shravan Jambukesan <shravan@shravanj.com>
 */

namespace FastFixedIncome.Standard.Library.Extensions
{
    public static class DateCalcExt
    {
        public static int CalculateDaysFromLastPaymentDateTo(this DateTime lastPaymentDate, DateTime requestDate,
            AccrualDayCount accrualDayCount)
        {
            int numberOfDays = 0;

            switch (accrualDayCount)
            {
                case AccrualDayCount.ActualBy360:
                    numberOfDays = CalculateNumberOfDaysBetweenPaymentMonths(lastPaymentDate, requestDate, false);
                    break;
                case AccrualDayCount.ActualBy365:
                    numberOfDays = CalculateNumberOfDaysBetweenPaymentMonths(lastPaymentDate, requestDate, false);
                    break;
                case AccrualDayCount.ThirtyBy360:
                    numberOfDays = CalculateNumberOfDaysBetweenPaymentMonths(lastPaymentDate, requestDate, true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(accrualDayCount), accrualDayCount, null);
            }

            return numberOfDays;
        }

        public static bool IsThirtyDayCount(this AccrualDayCount accrualDayCount)
        {
            bool isForThirtyDayCount = false;

            switch (accrualDayCount)
            {
                case AccrualDayCount.ActualBy360:
                    isForThirtyDayCount = true;
                    break;
                case AccrualDayCount.ActualBy365:
                    isForThirtyDayCount = false;
                    break;
                case AccrualDayCount.ThirtyBy360:
                    isForThirtyDayCount = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(accrualDayCount), accrualDayCount, null);
            }

            return isForThirtyDayCount;
        }

        public static bool AreRequestDatesValid(this DateTime requestDate, DateTime firstPaymentDate,
            DateTime maturityDate)
        {
            bool validDates = requestDate > firstPaymentDate && requestDate < maturityDate;

            if (!(maturityDate > firstPaymentDate))
            {
                validDates = false;
            }

            return validDates;
        }

        public static int CalculateDaysBetweenPaymentsUsing(this AccrualDayCount accrualDayCount,
            CouponPaymentFrequency couponPaymentFrequency, DateTime startPaymentDate, DateTime endPaymentDate)
        {
            int days = 0;

            switch (accrualDayCount)
            {
                case AccrualDayCount.ActualBy360:
                    switch (couponPaymentFrequency)
                    {
                        case CouponPaymentFrequency.Annual:
                            days = CalculateNumberOfDaysBetweenPaymentMonths(startPaymentDate, endPaymentDate, true);
                            break;
                        case CouponPaymentFrequency.SemiAnnual:
                            days = CalculateNumberOfDaysBetweenPaymentMonths(startPaymentDate, endPaymentDate, true) /
                                   2;
                            break;
                        case CouponPaymentFrequency.Quarterly:
                            days = CalculateNumberOfDaysBetweenPaymentMonths(startPaymentDate, endPaymentDate, true) /
                                   4;
                            break;
                        case CouponPaymentFrequency.Monthly:
                            days = CalculateNumberOfDaysBetweenPaymentMonths(startPaymentDate, endPaymentDate, true) /
                                   12;
                            break;
                        case CouponPaymentFrequency.Weekly:
                            days = CalculateNumberOfDaysBetweenPaymentMonths(startPaymentDate, endPaymentDate, true) /
                                   52;
                            break;
                        case CouponPaymentFrequency.Daily:
                            days = CalculateNumberOfDaysBetweenPaymentMonths(startPaymentDate, endPaymentDate, true) /
                                   360;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(couponPaymentFrequency),
                                couponPaymentFrequency, null);
                    }

                    break;
                case AccrualDayCount.ActualBy365:
                    switch (couponPaymentFrequency)
                    {
                        case CouponPaymentFrequency.Annual:
                            days = CalculateNumberOfDaysBetweenPaymentMonths(startPaymentDate, endPaymentDate, false);
                            break;
                        case CouponPaymentFrequency.SemiAnnual:
                            days = CalculateNumberOfDaysBetweenPaymentMonths(startPaymentDate, endPaymentDate, false) /
                                   2;
                            break;
                        case CouponPaymentFrequency.Quarterly:
                            days = CalculateNumberOfDaysBetweenPaymentMonths(startPaymentDate, endPaymentDate, false) /
                                   4;
                            break;
                        case CouponPaymentFrequency.Monthly:
                            days = CalculateNumberOfDaysBetweenPaymentMonths(startPaymentDate, endPaymentDate, false) /
                                   12;
                            break;
                        case CouponPaymentFrequency.Weekly:
                            days = CalculateNumberOfDaysBetweenPaymentMonths(startPaymentDate, endPaymentDate, false) /
                                   52;
                            break;
                        case CouponPaymentFrequency.Daily:
                            days = CalculateNumberOfDaysBetweenPaymentMonths(startPaymentDate, endPaymentDate, false) /
                                   365;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(couponPaymentFrequency),
                                couponPaymentFrequency, null);
                    }

                    break;
                case AccrualDayCount.ThirtyBy360:

                    switch (couponPaymentFrequency)
                    {
                        case CouponPaymentFrequency.Annual:
                            days = 1;
                            break;
                        case CouponPaymentFrequency.SemiAnnual:
                            days = 180;
                            break;
                        case CouponPaymentFrequency.Quarterly:
                            days = 120;
                            break;
                        case CouponPaymentFrequency.Monthly:
                            days = 12;
                            break;
                        case CouponPaymentFrequency.Weekly:
                            days = 52;
                            break;
                        case CouponPaymentFrequency.Daily:
                            days = CalculateNumberOfDaysBetweenPaymentMonths(startPaymentDate, endPaymentDate, true) /
                                   360;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(couponPaymentFrequency),
                                couponPaymentFrequency, null);
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(accrualDayCount), accrualDayCount, null);
            }

            return days;
        }

        private static int CalculateNumberOfDaysBetweenPaymentMonths(DateTime startDate, DateTime endDate,
            bool useThirtyDayCount)
        {
            int totalNumberOfDaysBetweenDates = 0;

            var currentDate = startDate;


            while (currentDate.Month <= endDate.Month)
            {
                var numberOfDaysPerMonth =
                    useThirtyDayCount ? 30 : DateTime.DaysInMonth(currentDate.Year, currentDate.Month);

                int daysRemainingInCurrentMonth = 0;

                if (currentDate.Month == startDate.Month)
                {
                    daysRemainingInCurrentMonth = numberOfDaysPerMonth - currentDate.Day;
                }
                else if (currentDate.Month == endDate.Month)
                {
                    daysRemainingInCurrentMonth = endDate.Day;
                }
                else
                {
                    daysRemainingInCurrentMonth = numberOfDaysPerMonth;
                }

                if (!(daysRemainingInCurrentMonth > 0))
                {
                    daysRemainingInCurrentMonth = numberOfDaysPerMonth;
                }

                totalNumberOfDaysBetweenDates += daysRemainingInCurrentMonth;

                currentDate = currentDate.AddMonths(1);
            }

            return totalNumberOfDaysBetweenDates;
        }

        public static IEnumerable<DateTime> GetDatesInRangeTo(this DateTime startDate, DateTime endDate)
        {
            var dates = new List<DateTime>();

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                dates.Add(date);
            }

            return dates;
        }

        public static int GetCouponPaymentFreqency(this CouponPaymentFrequency couponPaymentFrequency)
        {
            int paymentFrequency = 0;

            switch (couponPaymentFrequency)
            {
                case CouponPaymentFrequency.Annual:
                    paymentFrequency = 1;
                    break;
                case CouponPaymentFrequency.SemiAnnual:
                    paymentFrequency = 2;
                    break;
                case CouponPaymentFrequency.Quarterly:
                    paymentFrequency = 4;
                    break;
                case CouponPaymentFrequency.Monthly:
                    paymentFrequency = 12;
                    break;
                case CouponPaymentFrequency.Weekly:
                    paymentFrequency = 52;
                    break;
                case CouponPaymentFrequency.Daily:
                    paymentFrequency = 365;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(couponPaymentFrequency), couponPaymentFrequency, null);
            }

            return paymentFrequency;
        }
    }
}
