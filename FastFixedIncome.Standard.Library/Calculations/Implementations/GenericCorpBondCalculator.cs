using System;
using System.Collections.Generic;
using System.Text;
using FastFixedIncome.Standard.Library.Calculations.Interfaces;
using FastFixedIncome.Standard.Library.Extensions;
using FastFixedIncome.Standard.Library.Models;
using FastFixedIncome.Standard.Library.Models.Bonds;
using FastFixedIncome.Standard.Library.Models.Errors;

namespace FastFixedIncome.Standard.Library.Calculations.Implementations
{
    public class GenericCorpBondCalculator : IGenericCorpBondCalculator
    {
        public GenericBondAccruedInterestResult CalculateAccruedInterest(decimal parValue, decimal couponRate,
            DateTime firstPaymentDate, DateTime maturityDate, DateTime requestDate, AccrualDayCount accrualDayCount,
            CouponPaymentFrequency couponPaymentFrequency, int numberOfBonds)
        {
            decimal accruedInterest = 0;

            var errorList = new List<CalculationError>();

            if (!requestDate.AreRequestDatesValid(firstPaymentDate, maturityDate))
            {
                errorList.Add(new CalculationError(){ ErrorCode = ErrorCodes.BadDates, ErrorLevel = CalculationErrorLevel.Critical, ErrorMessage = ErrorMessages.InvalidRequestDates});
            }

            var adjustedCouponRate = CouponRateCalcExt.GetCouponRateUsing(couponRate, couponPaymentFrequency,
                accrualDayCount.IsThirtyDayCount());

            var daysBetweenLastPaymentDateAndRequestDate =
                firstPaymentDate.CalculateDaysFromLastPaymentDateTo(requestDate, accrualDayCount);

            var daysBetweenPayments =
                accrualDayCount.CalculateDaysBetweenPaymentsUsing(couponPaymentFrequency, firstPaymentDate,
                    maturityDate);

            accruedInterest = parValue * adjustedCouponRate *
                              (Convert.ToDecimal(daysBetweenLastPaymentDateAndRequestDate) / Convert.ToDecimal(daysBetweenPayments)) * numberOfBonds;

            return new GenericBondAccruedInterestResult()
            {
                AccruedInterest = accruedInterest,
                ErrorList = errorList
            };
        }
    }
}
