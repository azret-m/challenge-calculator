﻿using NUnit.Framework;
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
            ChallengeCalculator challengeCalculator = new ChallengeCalculator("1,2,3,4,5,6");

            Assert.That(() => challengeCalculator.Sum(), Throws.TypeOf<InputValidationException>());
        }

        [Test()]
        public void SumOfNullInput()
        {
            long expected = 0;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator(null);

            Assert.AreEqual(expected, challengeCalculator.Sum());
        }

        [Test()]
        public void SumOfEmptyInput()
        {
            long expected = 0;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("");

            Assert.AreEqual(expected, challengeCalculator.Sum());
        }

        [Test()]
        public void SumOfTwoNumbers()
        {
            long expected = 476;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("454,22");

            Assert.AreEqual(expected, challengeCalculator.Sum());
        }

        [Test()]
        public void SumOfOneNumber()
        {
            long expected = 400;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("400");

            Assert.AreEqual(expected, challengeCalculator.Sum());
        }

        [Test()]
        public void SumOfPartiallyInvalidNumbers()
        {
            long expected = 899;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("899,dfsdfsdfsf");

            Assert.AreEqual(expected, challengeCalculator.Sum());
        }

        [Test()]
        public void SumOfAllInvalidNumbers()
        {
            long expected = 0;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("riuwoeru,dfsdfsdfsf");

            Assert.AreEqual(expected, challengeCalculator.Sum());
        }

        [Test()]
        public void SumOfAllNumbers()
        {
            long expected = 108;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("1,2,5,10,20,70");

            Assert.AreEqual(expected, challengeCalculator.Sum());
        }

        [Test()]
        public void NewLineCharacterDelimeterSupport()
        {
            long expected = 108;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("1\n2,5,10\n20,70");

            Assert.AreEqual(expected, challengeCalculator.Sum());
        }

        [Test()]
        public void NegativeNumbersAreNotSupported()
        {
            ChallengeCalculator challengeCalculator = new ChallengeCalculator("-1,4,2,-20,30,40,-6");

            Assert.That(() => challengeCalculator.Sum(), Throws.TypeOf<NegativeNumbersNotSupportedException>());
        }

        [Test()]
        public void NumbersGreaterThan1000AreNotSupported()
        {
            long expected = 73;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("8000,1,2,1000,2000,70");

            Assert.AreEqual(expected, challengeCalculator.Sum());
        }

        [Test()]
        public void TestNewDelimeterOfASingleCharacter1()
        {
            long expected = 7;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("//#\n2#5");

            Assert.AreEqual(expected, challengeCalculator.Sum());
        }

        [Test()]
        public void TestNewDelimeterOfASingleCharacter2()
        {
            long expected = 102;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("//,\n2,ff,100");

            Assert.AreEqual(expected, challengeCalculator.Sum());
        }

        [Test()]
        public void TestNewDelimeterOfAnyLength()
        {
            long expected = 66;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("//[***]\n11***22***33");

            Assert.AreEqual(expected, challengeCalculator.Sum());
        }
    }
}
