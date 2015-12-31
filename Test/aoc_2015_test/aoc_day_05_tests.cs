using NUnit.Framework;
using aoc_day_05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace aoc_2015_test
{
    [TestFixture]
    public class aoc_day_05_tests
    {
        const string AOC_05_TEST_PATH = @".\TestFiles\aoc_day_05\";

        [SetUp]
        public void SetUpFixture()
        { }

        [Test]
        [TestCase("ugknbfddgicrmopn", ExpectedResult = true)]
        [TestCase("aaa", ExpectedResult = true)]
        [TestCase("jchzalrnumimnmhp", ExpectedResult = false)]
        [TestCase("haegwjzuvuyypxyu", ExpectedResult = false)]
        [TestCase("dvszwmarrgswjxmb", ExpectedResult = false)]
        public bool FunctionalTestA(string input)
        {
            return aoc_day_05.Program.IsNiceStringA(input);
        }

        [Test]
        [TestCase("aaa", ExpectedResult = false)]
        [TestCase("aaaa", ExpectedResult = true)]
        [TestCase("qjhvhtzxzqqjkmpb", ExpectedResult = true)]
        [TestCase("xxyxx", ExpectedResult = true)]
        [TestCase("uurcxstgmygtbstg", ExpectedResult = false)]
        [TestCase("ieodomkazucvgmuy", ExpectedResult = false)]
        public bool FunctionalTestB(string input)
        {
            return aoc_day_05.Program.IsNiceStringB(input);
        }
    }
}
