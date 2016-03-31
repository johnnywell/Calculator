using System.AddIn.Pipeline;
using CalcHVAs;
using CalculatorContracts;

namespace CalcHostSideAdapters
{
    [HostAdapter]
    public class CalculatorContractToViewHostSideAdapter : Calculator
    {
        private ICalc2Contract _contract;
        private ContractHandle _handle;

        public CalculatorContractToViewHostSideAdapter(ICalc2Contract contract)
        {
            _contract = contract;
            _handle = new ContractHandle(contract);
        }

        public override string Operations => _contract.GetAvailableOperations();

        public override double Operate(string operation, double a, double b)
        {
            return _contract.Operate(operation, a, b);
        }
    }
}
