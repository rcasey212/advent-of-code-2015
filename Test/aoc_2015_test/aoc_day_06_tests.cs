using NUnit.Framework;
using aoc_day_06;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2015_test
{
    [TestFixture]
    class aoc_day_06_tests
    {
        const string AOC_06_TEST_PATH = @".\TestFiles\aoc_day_06\";

        [SetUp]
        public void SetUpFixture()
        { }

        [Test]
        [TestCase(1000, 1000, 0, 0, 999, 999, ExpectedResult = 1000000)]
        [TestCase(1000, 1000, 0, 0, 999, 0, ExpectedResult = 1000)]
        public int LightArray_TurnOnRectangleTest(int width, int height, int startX, int startY, int endX, int endY)
        {
            LightArray lightArr = new LightArray(width, height);

            // turn off all lights
            lightArr.TurnOffAllLights();

            // turn on selected lights
            lightArr.TurnOnRectangle(new Point(startX, startY), new Point(endX, endY));

            // test count of turned-on lights
            return lightArr.GetCountOfLightsOn();
        }

        [Test]
        [TestCase(1000, 1000, 499, 499, 500, 500, ExpectedResult = 4)]
        public int LightArray_TurnOffRectangleTest(int width, int height, int startX, int startY, int endX, int endY)
        {
            LightArray lightArr = new LightArray(width, height);

            // turn on all lights
            lightArr.TurnOnAllLights();

            // turn off selected lights
            lightArr.TurnOffRectangle(new Point(startX, startY), new Point(endX, endY));

            // test count of turned-off lights
            return lightArr.GetCountOfLightsOff();
        }
    }
}
