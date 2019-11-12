using NUnit.Framework;
using challengecalculator.Classes;
using challengecalculator.Exceptions;

namespace UnitTests
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void SumOfMoreThanTwoNumbers()
        {
            ChallengeCalculator challengeCalculator = new ChallengeCalculator("1,2,3,4,5,6", "+", "%", false, 1000);

            Assert.That(() => challengeCalculator.Calculate().Result, Throws.TypeOf<InputValidationException>());
        }

        [Test()]
        public void SumOfNullInput()
        {
            long expected = 0;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator(null,"+", "%", false, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Result);
        }

        [Test()]
        public void SumOfEmptyInput()
        {
            long expected = 0;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("", "+", "%", false, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Result);
        }

        [Test()]
        public void SumOfTwoNumbers()
        {
            long expected = 476;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("454,22", "+", "%", false, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Result);
        }

        [Test()]
        public void SumOfOneNumber()
        {
            long expected = 400;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("400", "+", "%", false, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Result);
        }

        [Test()]
        public void SumOfPartiallyInvalidNumbers()
        {
            long expected = 899;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("899,dfsdfsdfsf", "+", "%", false, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Result);
        }

        [Test()]
        public void SumOfAllInvalidNumbers()
        {
            long expected = 0;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("riuwoeru,dfsdfsdfsf", "+", "%", false, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Result);
        }

        [Test()]
        public void SumOfAllNumbers()
        {
            long expected = 108;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("1,2,5,10,20,70", "+", "%", false, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Result);
        }

        [Test()]
        public void NewLineCharacterDelimeterSupport()
        {
            long expected = 108;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("1\n2,5,10\n20,70", "+", "%", false, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Result);
        }

        [Test()]
        public void NegativeNumbersAreNotSupported()
        {
            ChallengeCalculator challengeCalculator = new ChallengeCalculator("-1,4,2,-20,30,40,-6", "+", "%", false, 1000);

            Assert.That(() => challengeCalculator.Calculate().Result, Throws.TypeOf<NegativeNumbersNotSupportedException>());
        }

        [Test()]
        public void NumbersGreaterThan1000AreNotSupported()
        {
            long expected = 73;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("8000,1,2,1000,2000,70", "+", "%", false, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Result);
        }

        [Test()]
        public void TestNewDelimeterOfASingleCharacter1()
        {
            long expected = 7;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("//#\n2#5", "+", "%", false, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Result);
        }

        [Test()]
        public void TestNewDelimeterOfASingleCharacter2()
        {
            long expected = 102;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("//,\n2,ff,100", "+", "%", false, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Result);
        }

        [Test()]
        public void TestNewDelimeterOfAnyLength()
        {
            long expected = 66;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("//[***]\n11***22***33", "+", "%", false, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Result);
        }

        [Test()]
        public void TestNewMultipleDelimeterOfAnyLength()
        {
            long expected = 110;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("//[*][!!][r9r]\n11r9r22*hh*33!!44", "+", "%", false, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Result);
        }

        [Test()]
        public void TestSumOfNumbersWithNegativesIncluded()
        {
            long expected = -2;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("1,2,5,-10", "+", "%", true, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Result);
        }

        [Test()]
        public void TestMultiplicationOfNumbers()
        {
            long expected = 60;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("1,2,5,6", "*", "%", true, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Result);
        }

        [Test()]
        public void TestSubstructionOfNumbers()
        {
            long expected = -12;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("1,2,5,6", "-", "%", true, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Result);
        }

        [Test()]
        public void TestDivisionOfNumbers()
        {
            long expected = 25;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("100,2,2", "/", null, true, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Result);
        }

        [Test()]
        public void TestUpperBound100()
        {
            long expected = 4;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("102,2,2", "+", null, true, 100);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Result);
        }


        [Test()]
        public void TestSumFormula()
        {
            string expected = "102+2+2";

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("102,2,2", "+", null, true, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Formula);
        }

        [Test()]
        public void TestSubstractionFormula()
        {
            string expected = "102-2-2";

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("102,2,2", "-", null, true, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Formula);
        }

        [Test()]
        public void TestMultiplicationFormula()
        {
            string expected = "102*2*2";

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("102,2,2", "*", null, true, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Formula);
        }

        [Test()]
        public void TestDivisionFormula()
        {
            string expected = "102/2/2";

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("102,2,2", "/", null, true, 1000);

            Assert.AreEqual(expected, challengeCalculator.Calculate().Formula);
        }
    }
}
