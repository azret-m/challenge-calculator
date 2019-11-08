using System.Collections.Generic;
using challengecalculator.Exceptions;

namespace challengecalculator.Classes
{
    public class ChallengeCalculator
    {
        private string inputArgs;
        private char[] delimeters = { ',', '\n' };
        private const long InvalidNumberRange = 1000;

        public ChallengeCalculator(string inputArgs)
        {
            this.inputArgs = inputArgs;
        }

        public long GetSum()
        {
            if (string.IsNullOrEmpty(inputArgs))
            {
                return 0;
            }         
            else
            {
                string[] candidateNumbersList = inputArgs.Split(delimeters);

                return CalculateSum(candidateNumbersList);
            }
        }

        private long CalculateSum(string[] candidateNumbersList)
        {
            List<long> negativeNumbersList = new List<long>();

            long result = 0;
            foreach (string candidateNumber in candidateNumbersList)
            {
                bool canParse = long.TryParse(candidateNumber, out long number);

                number = canParse && number < InvalidNumberRange ? number : 0;

                if (IsNegative(number))
                {
                    negativeNumbersList.Add(number);
                }
                else
                {
                    if (negativeNumbersList.Count == 0)
                    {
                        result += number;
                    }
                }
            }

            if (negativeNumbersList.Count > 0)
            {
                throw new NegativeNumbersNotSupportedException(negativeNumbersList);
            }

            return result;
        }

        private bool IsNegative(long number)
        {
            return number < 0;
        }
    }
}
