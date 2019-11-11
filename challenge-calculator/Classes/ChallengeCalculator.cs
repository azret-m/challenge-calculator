using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using challengecalculator.Exceptions;

namespace challengecalculator.Classes
{
    public class ChallengeCalculator
    {
        private string inputArgs;
        private List<string> delimeters = new List<string>{ ",", "\n" };
        private string[] delimeterFormatList = { @"^\/\/(.)\n", @"^\/\/\[(.*?)\]\n" };

        private const long InvalidNumberRange = 1000;

        public ChallengeCalculator(string inputArgs)
        {
            this.inputArgs = inputArgs;
        }

        public long Sum()
        {
            if (string.IsNullOrEmpty(inputArgs))
            {
                return 0;
            }         
            else
            {
                foreach (var delimeterFormat in delimeterFormatList)
                {
                    var matchResult = Regex.Match(inputArgs, delimeterFormat);

                    if (matchResult.Success)
                    {
                        var delimeter = matchResult.Groups[1].ToString();
                        delimeters.Add(delimeter);
                    }
                }

                string[] candidateNumbersList = inputArgs.Split(delimeters.ToArray(), StringSplitOptions.None);

                return CalculateSum(candidateNumbersList);
            }
        }

        private long CalculateSum(string[] candidateNumbersList)
        {
            List<long> negativeNumbersList = new List<long>();

            long result = 0;
            foreach (string candidateNumber in candidateNumbersList)
            {
                long number = GetParsedNumber(candidateNumber);

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

        private long GetParsedNumber(string candidateNumber)
        {
            bool canParse = long.TryParse(candidateNumber, out long number);

            number = canParse && number < InvalidNumberRange ? number : 0;

            return number;
        }

        private bool IsNegative(long number)
        {
            return number < 0;
        }
    }
}
