using System;
using System.Collections.Generic;
using System.Text;
using FastFixedIncome.Standard.Library.Calculations.Interfaces;
using FastFixedIncome.Standard.Library.Extensions;
using FastFixedIncome.Standard.Library.Models;
using FastFixedIncome.Standard.Library.Models.Bonds;
using FastFixedIncome.Standard.Library.Models.Bonds.Results;
using FastFixedIncome.Standard.Library.Models.Errors;

/*
 * Fast Fixed Income Library - Generic Bond Calculator
 * Exposes calculation methods for generic bonds (corp, muni, etc)
 * Date: 7/17/2021
 * Author: Shravan Jambukesan <shravan@shravanj.com>
 */

namespace FastFixedIncome.Standard.Library.Calculations.Implementations
{
    public class GenericBondCalculator : IGenericBondCalculator
    {
        public GenericBondAccruedInterestResult CalculateAccruedInterest(decimal parValue, decimal couponRate,
            DateTime firstPaymentDate, DateTime maturityDate, DateTime requestDate, AccrualDayCount accrualDayCount,
            CouponPaymentFrequency couponPaymentFrequency, int numberOfBonds, int resultRounding = 0)
        {
            decimal accruedInterest = 0;

            var errorList = new List<CalculationError>();

            if (!requestDate.AreRequestDatesValid(firstPaymentDate, maturityDate))
            {
                errorList.Add(new CalculationError(){ ErrorCode = ErrorCodes.BadDates, ErrorLevel = CalculationErrorLevel.Critical, ErrorMessage = ErrorMessages.InvalidRequestDates});
            }

            if (couponRate <= 0)
            {
                errorList.Add(new CalculationError() { ErrorCode = ErrorCodes.BadCouponRate, ErrorLevel = CalculationErrorLevel.Critical, ErrorMessage = ErrorMessages.BadCouponRate });
            }

            if (parValue <= 0)
            {
                errorList.Add(new CalculationError() { ErrorCode = ErrorCodes.BadParValue, ErrorLevel = CalculationErrorLevel.Critical, ErrorMessage = ErrorMessages.BadParValue });
            }

            if (resultRounding < 0)
            {
                errorList.Add(new CalculationError() { ErrorCode = ErrorCodes.InvalidDecimalResultRounding, ErrorLevel = CalculationErrorLevel.Critical, ErrorMessage = ErrorMessages.BadRoundingSetting });
            }

            try
            {
                var adjustedCouponRate = CouponRateCalcExt.GetCouponRateUsing(couponRate, couponPaymentFrequency,
                    accrualDayCount.IsThirtyDayCount());

                var daysBetweenLastPaymentDateAndRequestDate =
                    firstPaymentDate.CalculateDaysFromLastPaymentDateTo(requestDate, accrualDayCount);

                var daysBetweenPayments =
                    accrualDayCount.CalculateDaysBetweenPaymentsUsing(couponPaymentFrequency, firstPaymentDate,
                        maturityDate);

                accruedInterest = parValue * adjustedCouponRate *
                                  (Convert.ToDecimal(daysBetweenLastPaymentDateAndRequestDate) / Convert.ToDecimal(daysBetweenPayments)) * numberOfBonds;

                if (resultRounding != 0)
                {
                    accruedInterest = decimal.Round(accruedInterest, resultRounding);
                }
            }
            catch (Exception e)
            {
                errorList.Add(new CalculationError() { ErrorCode = ErrorCodes.UnhandledException, ErrorLevel = CalculationErrorLevel.Critical, ErrorMessage = e.ToString()});
            }

            return new GenericBondAccruedInterestResult()
            {
                AccruedInterest = accruedInterest,
                ErrorList = errorList
            };
        }

        public GenericBondYieldToMaturityResult CalculateYieldToMaturity(decimal parValue, decimal currentPrice, decimal couponRate,
             DateTime requestDate, DateTime maturityDate, CouponPaymentFrequency couponPaymentFrequency)
        {
            var errorList = new List<CalculationError>();

            if (parValue <= 0)
            {
                errorList.Add(new CalculationError() { ErrorCode = ErrorCodes.BadParValue, ErrorLevel = CalculationErrorLevel.Critical, ErrorMessage = ErrorMessages.BadParValue });
            }

            if (currentPrice <= 0)
            {
                errorList.Add(new CalculationError() { ErrorCode = ErrorCodes.BadCurrentPrice, ErrorLevel = CalculationErrorLevel.Critical, ErrorMessage = ErrorMessages.BadCurrentPrice });
            }

            decimal ytm = 0;

            try
            {
                var yearsTillMaturity = maturityDate.Year - requestDate.Year;

                var couponPayment = parValue * couponRate * couponPaymentFrequency.GetCouponPaymentFreqency();

                var faceValueLessPresentValueOverTimeToMaturity = (parValue - currentPrice) / yearsTillMaturity;

                var faceValuePlusPresentValueByHalf = (parValue + currentPrice) / 2;

                ytm =
                    (couponPayment + faceValueLessPresentValueOverTimeToMaturity) /
                    (faceValuePlusPresentValueByHalf);
            }
            catch (Exception e)
            {
                errorList.Add(new CalculationError() { ErrorCode = ErrorCodes.UnhandledException, ErrorLevel = CalculationErrorLevel.Critical, ErrorMessage = e.ToString() });
            }

            return new GenericBondYieldToMaturityResult()
            {
                YieldToMaturity = ytm,
                ErrorList = errorList
            };
        }
    }
}
