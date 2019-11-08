using System;
using challengecalculator.Classes;

namespace challengecalculator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string arg = "-1,3,5,6,-9,20,-20";
            var challengecalculator = new ChallengeCalculator(arg);
            Console.WriteLine($"Sum Result : {challengecalculator.GetSum()}");          
        }
    }
}
