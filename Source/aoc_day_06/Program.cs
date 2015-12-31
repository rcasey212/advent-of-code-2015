using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_day_06
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = args[0];

            LightArray partA = new LightArray(1000, 1000);
            partA.TurnOffAllLights();

            foreach (Tuple<int,Point,Point> command in EnumerateCommands(filename))
            {
                switch (command.Item1)
                {
                    // turn on
                    case 0:
                        partA.TurnOnRectangle(command.Item2, command.Item3);
                        break;

                    // turn off
                    case 1:
                        partA.TurnOffRectangle(command.Item2, command.Item3);
                        break;

                    // toggle
                    case 2:
                        partA.ToggleRectangle(command.Item2, command.Item3);
                        break;
                    default:
                        throw new Exception("n0pe!");
                }
            }

            System.Console.WriteLine("Part A: The number of lights on is \"{0}\".", partA.GetCountOfLightsInState(true));
        }

        static IEnumerable<Tuple<int, Point, Point>> EnumerateCommands(string filename)
        {
            int operation = 0;

            using (StreamReader fileReader = new StreamReader(filename))
            {
                string line;
                while (null != (line = fileReader.ReadLine()))
                {
                    line = line.Replace(" through ", "|");

                    if (line.StartsWith("turn on "))
                    {
                        operation = 0;
                        line = line.Replace("turn on ", "");
                    }
                    else if (line.StartsWith("turn off "))
                    {
                        operation = 1;
                        line = line.Replace("turn off ", "");
                    }
                    else if (line.StartsWith("toggle "))
                    {
                        operation = 2;
                        line = line.Replace("toggle ", "");
                    }
                    else
                    {
                        throw new Exception("Operation not supported.");
                    }

                    string[] unparsedPoints = line.Split(new char[] { '|' });
                    string[] startPointToParse = unparsedPoints[0].Split(new char[] { ',' });
                    string[] endPointToParse = unparsedPoints[1].Split(new char[] { ',' });

                    Point startPoint = new Point(int.Parse(startPointToParse[0]), int.Parse(startPointToParse[1]));
                    Point endPoint = new Point(int.Parse(endPointToParse[0]), int.Parse(endPointToParse[1]));

                    yield return new Tuple<int, Point, Point>(operation, startPoint, endPoint);
                }

                fileReader.Close();
            }
        }
    }
}
