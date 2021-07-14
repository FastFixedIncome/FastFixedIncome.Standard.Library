using System;
using System.Collections.Generic;
using System.Text;

namespace FastFixedIncome.Standard.Library.Models.Bonds
{
    public class GenericBondAccruedInterestResult
    {
        public decimal AccruedInterest { get; set; }
        public IEnumerable<CalculationError> ErrorList { get; set; } = null;
    }
}
