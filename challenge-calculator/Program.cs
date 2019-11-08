using System;
using challengecalculator.Classes;

namespace challengecalculator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string arg = "8000,1,2,1000,2000,70";
            var challengecalculator = new ChallengeCalculator(arg);
            Console.WriteLine($"Sum Result : {challengecalculator.GetSum()}");          
        }
    }
}
