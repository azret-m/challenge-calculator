using System.Collections.Generic;
using challengecalculator.Exceptions;

namespace challengecalculator.Classes
{
    public class Numbers
    {
        private long upperBoundNumber;
        private string[] candidateNumbersList;
        private bool supportNegativeNumbers;

        public Numbers(
            string[] candidateNumbersList,
            long upperBoundNumber,
            bool supportNegativeNumbers
        )
        {
            this.candidateNumbersList = candidateNumbersList;
            this.upperBoundNumber = upperBoundNumber;
            this.supportNegativeNumbers = supportNegativeNumbers;
        }

        /*
         * Gets a list of numbers for calculations
         *
         * @return List<long>
         */
        public List<long> Get()
        {
            List<long> numbersList = new List<long>();
            List<long> negativeNumbersList = new List<long>();

            foreach (string candidateNumber in this.candidateNumbersList)
            {
                long number = GetParsedNumber(candidateNumber);

                if (!supportNegativeNumbers && number < 0)
                {
                    negativeNumbersList.Add(number);
                }
                else
                {
                    if (negativeNumbersList.Count == 0)
                    {
                        numbersList.Add(number);
                    }
                }
            }

            if (negativeNumbersList.Count > 0)
            {
                throw new NegativeNumbersNotSupportedException(negativeNumbersList);
            }

            return numbersList;
        }

        /*
         * Parses the number from string to long
         *
         * @return long
         */
        private long GetParsedNumber(string candidateNumber)
        {
            bool canParse = long.TryParse(candidateNumber, out long number);

            number = canParse && number < upperBoundNumber ? number : 0;

            return number;
        }
    }
}
