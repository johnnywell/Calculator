using System.AddIn.Pipeline;

namespace CalcAddInViews
{
    [AddInBase]
    public abstract class Calculator2
    {
        public abstract string Operations { get; }

        public abstract double Operate(string operation, double a, double b);
    }
}
