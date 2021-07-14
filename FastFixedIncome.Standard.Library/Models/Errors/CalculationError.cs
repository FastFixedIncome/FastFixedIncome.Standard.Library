using System;
using System.Collections.Generic;
using System.Text;

namespace FastFixedIncome.Standard.Library.Models
{
    public class CalculationError
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public CalculationErrorLevel ErrorLevel { get; set; }
    }
}
