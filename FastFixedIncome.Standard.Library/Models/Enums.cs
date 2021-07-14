using System;
using System.Collections.Generic;
using System.Text;

namespace FastFixedIncome.Standard.Library.Models
{

    public enum AccrualDayCount
    {
        ActualBy360,
        ActualBy365,
        ThirtyBy360
    }

    public enum CouponPaymentFrequency
    {
        Annual,
        SemiAnnual,
        Quarterly,
        Monthly,
        Weekly, 
        Daily
    }

    public enum CalculationErrorLevel
    {
        Warning,
        Critical
    }
}
