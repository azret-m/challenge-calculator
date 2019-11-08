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
            ChallengeCalculator challengeCalculator = new ChallengeCalculator("1,2,3,4,5,6");

            Assert.That(() => challengeCalculator.GetSum(), Throws.TypeOf<InputValidationException>());
        }

        [Test()]
        public void SumOfNullInput()
        {
            long expected = 0;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator(null);

            Assert.AreEqual(expected, challengeCalculator.GetSum());
        }

        [Test()]
        public void SumOfEmptyInput()
        {
            long expected = 0;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("");

            Assert.AreEqual(expected, challengeCalculator.GetSum());
        }

        [Test()]
        public void SumOfTwoNumbers()
        {
            long expected = 476;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("454,22");

            Assert.AreEqual(expected, challengeCalculator.GetSum());
        }

        [Test()]
        public void SumOfOneNumber()
        {
            long expected = 400;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("400");

            Assert.AreEqual(expected, challengeCalculator.GetSum());
        }

        [Test()]
        public void SumOfPartiallyInvalidNumbers()
        {
            long expected = 899;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("899,dfsdfsdfsf");

            Assert.AreEqual(expected, challengeCalculator.GetSum());
        }

        [Test()]
        public void SumOfAllInvalidNumbers()
        {
            long expected = 0;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("riuwoeru,dfsdfsdfsf");

            Assert.AreEqual(expected, challengeCalculator.GetSum());
        }

        [Test()]
        public void SumOfAllNumbers()
        {
            long expected = 108;

            ChallengeCalculator challengeCalculator = new ChallengeCalculator("1,2,5,10,20,70");

            Assert.AreEqual(expected, challengeCalculator.GetSum());
        }
    }
}
