
namespace CalcHVAs
{
    public abstract class Calculator
    {
        public abstract string Operations { get; }

        public abstract double Operate(string operation, double a, double b);
    }
}
