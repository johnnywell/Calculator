using System;
using System.AddIn.Pipeline;
using CalcAddInViews;
using CalculatorContracts;

namespace AddInSideV1toV2Adapter
{
    [AddInAdapter]
    public class Calc2V1ViewToV2ContractAddInSideAdapter : ContractBase, ICalc2Contract
    {
        ICalculator _view;

        public Calc2V1ViewToV2ContractAddInSideAdapter(ICalculator calc)
        {
            _view = calc;
        }

        public string GetAvailableOperations()
        {
            return "+, -, *, /";
        }

        public double Operate(string operation, double a, double b)
        {
            switch (operation)
            {
                case "+":
                    return _view.Add(a, b);
                case "-":
                    return _view.Subtract(a, b);
                case "*":
                    return _view.Multiply(a, b);
                case "/":
                    return _view.Divide(a, b);
                default:
                    throw new InvalidOperationException("This add-in does not support: " + operation);
            }
        }
    }
}
