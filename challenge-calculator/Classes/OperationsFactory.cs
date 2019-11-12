using System.Linq;
using System.Collections.Generic;
using System;

namespace challengecalculator.Classes
{
    public class OperationsFactory
    {
        private List<long> numbersList;

        public OperationsFactory(List<long> numbersList)
        {
            this.numbersList = numbersList;
        }

        /*
         * Determines which operation to perform.
         *
         * @return CalculationResult
         */
        public CalculationResult GetResult(string operation)
        {
            switch (operation)
            {
                case "+":
                    return new CalculationResult()
                    {
                        Result = numbersList.Aggregate((x, y) => x + y),
                        Formula = GetFormula(operation)
                    };
                case "-":
                    return new CalculationResult()
                    {
                        Result = numbersList.Aggregate((x, y) => x - y),
                        Formula = GetFormula(operation)
                    };
                case "*":
                    return new CalculationResult()
                    {
                        Result = numbersList.Aggregate((x, y) => x * y),
                        Formula = GetFormula(operation)
                    };
                case "/":
                    return new CalculationResult()
                    {
                        Result = numbersList.Aggregate((x, y) => x / y),
                        Formula = GetFormula(operation)
                    };
                default:
                    return new CalculationResult()
                    {
                        Result = numbersList.Aggregate((x, y) => x + y),
                        Formula = GetFormula(operation)
                    };
            }
        }

        /*
         * Generates a formula.
         *
         * @return string
         */
        private string GetFormula(string operation)
        {
            string result = "";
            foreach (var number in this.numbersList)
            {
                result = result + Convert.ToString(number) + operation;
            }

            return result.Remove(result.Length - 1, 1);
        }
    }
}
