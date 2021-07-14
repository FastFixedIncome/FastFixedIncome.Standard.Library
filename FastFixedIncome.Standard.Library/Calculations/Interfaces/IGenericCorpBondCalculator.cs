using System;
using System.Collections.Generic;
using System.Text;
using FastFixedIncome.Standard.Library.Models;
using FastFixedIncome.Standard.Library.Models.Bonds;

namespace FastFixedIncome.Standard.Library.Calculations.Interfaces
{
    public interface IGenericCorpBondCalculator
    {
        GenericBondAccruedInterestResult CalculateAccruedInterest(decimal parValue, decimal couponRate,
            DateTime firstPaymentDate, DateTime maturityDate, DateTime requestDate, AccrualDayCount accrualDayCount,
            CouponPaymentFrequency couponPaymentFrequency, int numberOfBonds);
    }
}
