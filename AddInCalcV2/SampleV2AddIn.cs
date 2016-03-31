using System;
using System.AddIn;
using System.AddIn.Pipeline;
using CalcAddInViews;

namespace CalcAddIns
{
    // This pipeline segment has 
    // two attributes:
    // 1 - An AddInAttribute to identify
    //     this segment as an add-in.
    //
    // 2 - A QualificationDataAttribute to 
    //     indicate that the add-in should 
    //     be loaded int oa new application domain.
    [AddIn("Calculator Add-in", Version="2.0.0.0")]
    [QualificationData("Isolation", "NewAppDomain")]
    public class SampleV2AddIn: Calculator2
    {
        public override string Operations => "+, -, *, /, **";

        public override double Operate(string operation, double a, double b)
        {
            switch (operation)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    return a / b;
                case "**":
                    return Math.Pow(a, b);
                default:
                    throw new InvalidOperationException("This add-in does not support: " + operation);
            }
        }
    }
}
