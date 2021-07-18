using System.Collections.Generic;
using FastFixedIncome.Standard.Library.Models.Errors;

/*
 * Fast Fixed Income Library - Generic Bond Yield To Maturity Result
 * Entity for encapsulating calculated yield to maturity for generic bonds
 * Date: 7/17/2021
 * Author: Shravan Jambukesan <shravan@shravanj.com>
 */

namespace FastFixedIncome.Standard.Library.Models.Bonds.Results
{
    public class GenericBondYieldToMaturityResult
    {
        public decimal YieldToMaturity { get; set; }
        public IEnumerable<CalculationError> ErrorList { get; set; }
    }
}
