using System;
using System.Collections.Generic;
using System.Text;

/*
 * Fast Fixed Income Library - Generic Face Value (Par value)
 * Entity for encapsulating generic face value
 * Date: 7/17/2021
 * Author: Shravan Jambukesan <shravan@shravanj.com>
 */

namespace FastFixedIncome.Standard.Library.Models.Bonds
{
    public class GenericFaceValue
    {
        public double FaceValue { get; set; }
        public double YieldToMaturity { get; set; }
        public int TimeToMaturity { get; set; }
    }
}
