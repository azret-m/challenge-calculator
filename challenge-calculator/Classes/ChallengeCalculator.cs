using System;

namespace challengecalculator.Classes
{
    public class ChallengeCalculator
    {
        private string inputString;
        private string operation;
        private long upperBoundNumber;
        private bool supportNegativeNumbers;
        private string delimeter;

        public ChallengeCalculator(
            string inputString,
            string operation,
            string delimeter,
            bool supportNegativeNumbers = false,
            long upperBoundNumber = 1000
        )
        {
            this.inputString = inputString;
            this.operation = operation;
            this.delimeter = delimeter;
            this.supportNegativeNumbers = supportNegativeNumbers;
            this.upperBoundNumber = upperBoundNumber;
        }

        /*
         * Executes the caluclation.
         *
         * @return CalculationResult
         */
        public CalculationResult Calculate()
        {
            if (string.IsNullOrEmpty(this.inputString))
            {
                return new CalculationResult()
                {
                    Result = 0,
                    Formula = "0"
                };
            }
            else
            {
                Delimeters delimeters = new Delimeters(this.inputString, this.delimeter);
                string[] candidateNumbersList = this.inputString.Split(delimeters.Get(), StringSplitOptions.None);

                Numbers numbers = new Numbers(candidateNumbersList, this.upperBoundNumber, this.supportNegativeNumbers);
                OperationsFactory operationsFactory = new OperationsFactory(numbers.Get());

                return operationsFactory.GetResult(this.operation);
            }
        }
    }
}
