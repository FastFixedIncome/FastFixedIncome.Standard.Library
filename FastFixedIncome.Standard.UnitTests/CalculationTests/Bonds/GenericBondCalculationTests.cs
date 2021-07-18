using System;
using System.Collections.Generic;
using System.Text;
using FastFixedIncome.Standard.Library.Calculations.Implementations;
using FastFixedIncome.Standard.Library.Calculations.Interfaces;
using FastFixedIncome.Standard.Library.Models;
using FluentAssertions;
using NUnit.Framework;

namespace FastFixedIncome.Standard.UnitTests.CalculationTests.Bonds
{
    public class GenericBondCalculationTests
    {
        [Test]
        public void Single_GenericBond_ThirtyBy360Accrual_SemiAnnualCoupon_NoRounding_Success_Test()
        {
            decimal parValue = 1000;

            decimal couponRate = new decimal(0.027);

            var maturityDate = new DateTime(2022, 10, 9);

            var firstPaymentDate = new DateTime(2013, 4, 9);

            var requestDate = new DateTime(2013, 7, 19);

            IGenericBondCalculator calc = new GenericBondCalculator();

            var result = calc.CalculateAccruedInterest(parValue, couponRate, firstPaymentDate, maturityDate,
                requestDate, AccrualDayCount.ThirtyBy360, CouponPaymentFrequency.SemiAnnual, 1);

            result.AccruedInterest.Should().Be(7.5000000000000000000000000006M);
            result.ErrorList.Should().BeNullOrEmpty();
        }

        [Test]
        public void Single_GenericBond_ThirtyBy360Accrual_SemiAnnualCoupon_TwoDecimalRounding_Success_Test()
        {
            decimal parValue = 1000;

            decimal couponRate = new decimal(0.027);

            var maturityDate = new DateTime(2022, 10, 9);

            var firstPaymentDate = new DateTime(2013, 4, 9);

            var requestDate = new DateTime(2013, 7, 19);

            IGenericBondCalculator calc = new GenericBondCalculator();

            var result = calc.CalculateAccruedInterest(parValue, couponRate, firstPaymentDate, maturityDate,
                requestDate, AccrualDayCount.ThirtyBy360, CouponPaymentFrequency.SemiAnnual, 1, 2);

            result.AccruedInterest.Should().Be(7.50M);
            result.ErrorList.Should().BeNullOrEmpty();
        }

        [Test]
        public void Single_GenericBond_Ytm_Success_Test()
        {
            decimal parValue = 1000;
            decimal currentPrice = 850;

            IGenericBondCalculator calc = new GenericBondCalculator();

            var result = calc.CalculateYieldToMaturity(parValue, currentPrice, 0.15M, DateTime.Today,
                DateTime.Today.AddYears(7), CouponPaymentFrequency.Annual);

            result.YieldToMaturity.Should().Be(0.1853281853281853281853281853M);
            result.ErrorList.Should().BeNullOrEmpty();
        }
    }
}
