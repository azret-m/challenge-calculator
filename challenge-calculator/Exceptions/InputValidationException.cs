using System;
namespace challengecalculator.Exceptions
{
    public class InputValidationException : Exception
    {
        public InputValidationException() : base("More than 2 numbers are provided")
        {

        }
    }
}
