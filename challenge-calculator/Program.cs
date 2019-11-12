using System;
using challengecalculator.Classes;

namespace challengecalculator
{
    class MainClass
    {
        /*
         * args[0] - input string
         * args[1] - oparation (+,-,*,/)
         * args[2] - customer delimeter
         * args[3] - support negative numbers
         * args[4] - upper bound number
         */
        public static void Main(string[] args)
        {
            var challengecalculator = new ChallengeCalculator(args[0], args[1], args[2], Convert.ToBoolean(args[3]), Convert.ToInt64(args[4]));

            Console.WriteLine($"Calculation Result : {challengecalculator.Calculate().Result}");
            Console.WriteLine($"Calculation Formula : {challengecalculator.Calculate().Formula}");
        }
    }
}
