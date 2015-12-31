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
            HashSet<Coordinate> houses = new HashSet<Coordinate>();
            int x = 0;
            int y = 0;

            // Add initial house (starting position)
            Coordinate initialHouse = new Coordinate(x, y);
            houses.Add(initialHouse);

            using (StreamReader fileReader = new StreamReader(filename))
            {
                while (fileReader.Peek() > 0)
                {
                    char c = (char)fileReader.Read();

                    switch (c)
                    {
                        case '<':
                            x--;
                            break;
                        case '>':
                            x++;
                            break;
                        case '^':
                            y++;
                            break;
                        case 'v':
                            y--;
                            break;
                        default:
                            throw new Exception("The land of 10,000 NOPES.");
                    }

                    Coordinate coord = new Coordinate(x, y);
                    if (!houses.Contains(coord))
                    {
                        houses.Add(coord);
                    }
                }

                fileReader.Close();
            }

            int numberOfHouses = houses.Count;
            System.Console.WriteLine("The number of houses Santa visited is \"{0}\".", numberOfHouses);
        }
    }
}
