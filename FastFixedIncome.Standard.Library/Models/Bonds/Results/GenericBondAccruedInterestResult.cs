using System.Collections.Generic;
using FastFixedIncome.Standard.Library.Models.Errors;

/*
 * Fast Fixed Income Library - Generic Bond Accrued Interest Result
 * Entity for encapsulating calculated accrued interest for generic bonds
 * Date: 7/17/2021
 * Author: Shravan Jambukesan <shravan@shravanj.com>
 */

namespace FastFixedIncome.Standard.Library.Models.Bonds.Results
{
    public class GenericBondAccruedInterestResult
    {
        public decimal AccruedInterest { get; set; }
        public IEnumerable<CalculationError> ErrorList { get; set; } = null;
    }
}
