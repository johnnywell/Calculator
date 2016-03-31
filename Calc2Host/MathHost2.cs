using System;
using System.AddIn.Hosting;
using System.Collections.ObjectModel;
using CalcHVAs;

namespace MathHost
{
    class Program
    {
        static void Main()
        {
            // Assume that the current directory is the application folder,
            // and that it contains the pipeline folder structure.
            string addInRoot = Environment.CurrentDirectory + "\\Pipeline";

            while (true)
            {
                // Check to see if new add-ins have been installed.
                AddInStore.Rebuild(addInRoot);

                // Search for Calculator add-ins.
                Collection<AddInToken> tokens = AddInStore.FindAddIns(typeof(Calculator), addInRoot);

                // Ask the user which add-in they would like to use.
                AddInToken calcToken = ChooseCalculator(tokens);

                // Activate the selected AddIntoken in a new 
                // application domain with the internet trust level.
                Calculator calculator = calcToken.Activate<Calculator>(AddInSecurityLevel.Internet);
                
                //Run the add-in.
                RunCalculator(calculator);
            }
           
        }

        private static AddInToken ChooseCalculator(Collection<AddInToken> tokens)
        {
            if (tokens.Count == 0)
            {
                Console.WriteLine("No calculators are available");
                return null;
            }
            Console.WriteLine("Available Calculators: ");
            
            // Show the token properties for each token
            // in the AddInToken collection (tokens),
            // preceded by the add-in number in [] brackets.
            int tokNumber = 1;
            foreach (var tok in tokens)
            {
                Console.WriteLine(String.Format("\t[{0}]: {1} - {2}\n\t{3}\n\t\t {4}\n\t\t {5} - {6}",
                    tokNumber.ToString(),
                    tok.Name,
                    tok.AddInFullName,
                    tok.AssemblyName,
                    tok.Description,
                    tok.Version,
                    tok.Publisher));
                tokNumber ++;
            }

            Console.WriteLine("Which calculator do you want to use?");
            string line = Console.ReadLine();
            int selection;
            if (Int32.TryParse(line, out selection))
            {
                if (selection <= tokens.Count)
                {
                    return tokens[selection - 1];
                }
            }
            else if (line.Equals("exit"))
            {
                Environment.Exit(0);
            }
            Console.WriteLine("Invalid selection: {0}. Please choose again", line);
            return ChooseCalculator(tokens);
        }

        private static void RunCalculator(Calculator calc)
        {
            if (calc == null)
            {
                // No calculators were found, read a line and exit.
                Console.WriteLine();
            }

            Console.WriteLine("Available operations: " + calc.Operations);
            Console.WriteLine("Type \"menu\" or \"exit\" to change Add-In or exit");

            string line = Console.ReadLine();
            while (!line.Equals("exit"))
            {
                // The Parser class parses the user's input.
                try
                {
                    var c = new Parser(line);
                    Console.WriteLine(calc.Operate(c.Action, c.A, c.B));
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid command: {0}. Commands must be formated: [number] [operation] [number]", line);
                    Console.WriteLine("Available operations: " + calc.Operations);
                }

                line = Console.ReadLine();
            }
        }
    }

    internal class Parser
    {
        public Parser(string line)
        {
            String[] parts = line.Trim().Split(' ');
            A = Double.Parse(parts[0]);
            Action = parts[1];
            B = Double.Parse(parts[2]);
        }

        public double A { get; }

        public double B { get; }

        public String Action { get; }
    }
}
