using NUnit.Framework;
using System;
using System.IO;
using aoc_day_03;


namespace aoc_2015_test
{
    [TestFixture]
    public class aoc_day_03_tests
    {
        const string AOC_03_TEST_PATH = @".\TestFiles\aoc_day_03\";

        [SetUp]
        public void SetUpFixture()
        { }

        [Test]
        [TestCase("test_01.txt", ExpectedResult = 2)]
        [TestCase("test_02.txt", ExpectedResult = 4)]
        [TestCase("test_03.txt", ExpectedResult = 2)]
        public int Test_03_A(string testInput)
        {
            return Runner.Day_03_Part_A(Path.Combine(AOC_03_TEST_PATH, testInput));
        }

        [Test]
        [TestCase("test_01.txt", ExpectedResult = 3)]
        [TestCase("test_02.txt", ExpectedResult = 3)]
        [TestCase("test_03.txt", ExpectedResult = 11)]
        public int Test_03_B(string testInput)
        {
            return Runner.Day_03_Part_B(Path.Combine(AOC_03_TEST_PATH, testInput));
        }
    }
}
