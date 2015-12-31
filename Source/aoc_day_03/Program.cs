using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_day_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = args[0];

            int numberOfHousesSantaVisited = Runner.Day_03_Part_A(filename);
            System.Console.WriteLine("The number of houses Santa visited is \"{0}\".", numberOfHousesSantaVisited);

            int numberOfHousesSantaAndRoboSantaVisited = Runner.Day_03_Part_B(filename);
            System.Console.WriteLine("The number of houses Santa and Robo-Santa visited is \"{0}\".", numberOfHousesSantaAndRoboSantaVisited);
        }
    }
}
