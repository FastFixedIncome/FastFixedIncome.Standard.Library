using System;
using FastFixedIncome.Standard.Library.Calculations.Implementations;
using FastFixedIncome.Standard.Library.Calculations.Interfaces;
using FastFixedIncome.Standard.Library.Extensions;
using FastFixedIncome.Standard.Library.Models;

namespace FastFixedIncome.Standard.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            decimal parValue = 1000;

            decimal couponRate = new decimal(0.027);

            var maturityDate = new DateTime(2022, 10, 9);

            var firstPaymentDate = new DateTime(2013, 4, 9);

            var requestDate = new DateTime(2013, 7, 19);

            IGenericBondCalculator calc = new GenericBondCalculator();

            var interest = calc.CalculateAccruedInterest(parValue, couponRate, firstPaymentDate, maturityDate,
                requestDate, AccrualDayCount.ThirtyBy360, CouponPaymentFrequency.SemiAnnual, 1, 2);

            System.Console.WriteLine("Accrued Interest: " +  interest.AccruedInterest);
        }
    }
}
