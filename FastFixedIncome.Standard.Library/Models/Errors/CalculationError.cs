/*
 * Fast Fixed Income Library - Calculation Error
 * Entity for encapsulating calculation error details
 * Date: 7/17/2021
 * Author: Shravan Jambukesan <shravan@shravanj.com>
 */

namespace FastFixedIncome.Standard.Library.Models.Errors
{
    public class CalculationError
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public CalculationErrorLevel ErrorLevel { get; set; }
    }
}
