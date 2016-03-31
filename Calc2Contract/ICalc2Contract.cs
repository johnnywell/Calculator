using System;
using System.AddIn.Contract;
using System.AddIn.Pipeline;

namespace CalculatorContracts
{
    [AddInContract]
    public interface ICalc2Contract : IContract
    {
        string GetAvailableOperations();
        double Operate(string operation, double a, double b);
    }
}