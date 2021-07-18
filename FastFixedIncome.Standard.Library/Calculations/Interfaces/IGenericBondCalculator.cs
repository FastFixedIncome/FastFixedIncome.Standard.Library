using System;
using System.Collections.Generic;
using System.Text;
using FastFixedIncome.Standard.Library.Models;
using FastFixedIncome.Standard.Library.Models.Bonds;
using FastFixedIncome.Standard.Library.Models.Bonds.Results;

namespace FastFixedIncome.Standard.Library.Calculations.Interfaces
{
    public interface IGenericBondCalculator
    {
        GenericBondAccruedInterestResult CalculateAccruedInterest(decimal parValue, decimal couponRate,
            DateTime firstPaymentDate, DateTime maturityDate, DateTime requestDate, AccrualDayCount accrualDayCount,
            CouponPaymentFrequency couponPaymentFrequency, int numberOfBonds, int resultRounding = 0);

        GenericBondYieldToMaturityResult CalculateYieldToMaturity(decimal parValue, decimal currentPrice,
            decimal couponRate,
            DateTime requestDate, DateTime maturityDate, CouponPaymentFrequency couponPaymentFrequency);


    }
}
