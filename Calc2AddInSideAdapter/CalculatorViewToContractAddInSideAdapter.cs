using System.AddIn.Pipeline;
using CalcAddInViews;
using CalculatorContracts;

namespace CalcAddInSideAdapters
{
    [AddInAdapter]
    public class CalculatorViewToContractAddInSideAdapter : ContractBase, ICalc2Contract
    {
        private Calculator2 _view;

        public CalculatorViewToContractAddInSideAdapter(Calculator2 calculator)
        {
            _view = calculator;
        }

        public string GetAvailableOperations()
        {
            return _view.Operations;
        }

        public double Operate(string operation, double a, double b)
        {
            return _view.Operate(operation, a, b);
        }
    }
}
