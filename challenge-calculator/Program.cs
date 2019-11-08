using System;
using challengecalculator.Classes;

namespace challengecalculator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var challengecalculator = new ChallengeCalculator(args[0]);
            Console.WriteLine($"Sum Result : {challengecalculator.GetSum()}");          
        }
    }
}
