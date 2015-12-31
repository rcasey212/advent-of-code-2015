using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace aoc_2015_test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> runnerArgs = new List<string>();
            runnerArgs.Add(Assembly.GetExecutingAssembly().Location);
            runnerArgs.Add("/run=aoc_2015_test.aoc_day_06_tests");
            //runnerArgs.Add("/run=aoc_2015_test.aoc_day_05_tests.FunctionalTestB");
            NUnit.ConsoleRunner.Runner.Main(runnerArgs.ToArray());
        }
    }
}
