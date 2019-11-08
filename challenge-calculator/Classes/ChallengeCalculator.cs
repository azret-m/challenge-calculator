using challengecalculator.Exceptions;

namespace challengecalculator.Classes
{
    public class ChallengeCalculator
    {
        private string inputArgs;

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
                string[] candidateNumbersList = inputArgs.Split(',');

                if (candidateNumbersList.Length > 2)
                {
                    throw new InputValidationException();
                }
                else
                {
                    return CalculateSum(candidateNumbersList);
                }
            }
        }

        private long CalculateSum(string[] candidateNumbersList)
        {
            long result = 0;
            foreach (string candidateNumber in candidateNumbersList)
            {
                bool canParse = long.TryParse(candidateNumber, out long number);

                number = canParse ? number : 0;

                result += number;
            }

            return result;
        }

    }
}
