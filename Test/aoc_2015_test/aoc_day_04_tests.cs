using NUnit.Framework;
using System;
using System.IO;
using aoc_day_04;


namespace aoc_2015_test
{
    [TestFixture]
    public class aoc_day_04_tests
    {
        [SetUp]
        public void SetUpFixture()
        { }

        [Test]
        [TestCase("abcdef", "00000", ExpectedResult = 609043)]
        [TestCase("pqrstuv", "00000", ExpectedResult = 1048970)]
        //[TestCase("ckczppom", "00000", ExpectedResult = 117946)]
        //[TestCase("ckczppom", "000000", ExpectedResult = 3938038)]
        public int Test_04(string keyRoot, string hashRoot)
        {
            return aoc_day_04.Program.FindMinPositiveIntUsingKeyRootThatCreatesHasWithHashRoot(keyRoot, hashRoot);
        }
    }
}
