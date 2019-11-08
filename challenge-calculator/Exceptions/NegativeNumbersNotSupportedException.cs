using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace challengecalculator.Exceptions
{
    public class NegativeNumbersNotSupportedException : Exception
    {
        public NegativeNumbersNotSupportedException(List<long> negativeNumbersList) :
            base($"Negative numbers are not supported: {JsonConvert.SerializeObject(negativeNumbersList)}")
        {
        }
    }
}
