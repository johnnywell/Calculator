using System.AddIn.Pipeline;
using System.Runtime.Remoting.Channels;
using CalcAddInViews;
using CalculatorContracts;

namespace CalcAddInsideAdapter
{
    // The AddInAdapterAttribute identifies this class as the add-in-side adapter
    // pipeline segment.
    [AddInAdapter()]
    public class CalculatorViewToContractAddinSideAdapter : ContractBase, ICalc1Contract
    {
        private ICalculator _view;

        public CalculatorViewToContractAddinSideAdapter(ICalculator view)
        {
            _view = view;
        }

        public double Add(double a, double b)
        {
            return _view.Add(a, b);
        }

        public double Subtract(double a, double b)
        {
            return _view.Subtract(a, b);
        }

        public double Multiply(double a, double b)
        {
            return _view.Multiply(a, b);
        }

        public double Divide(double a, double b)
        {
            return _view.Divide(a, b);
        }
    }
}
