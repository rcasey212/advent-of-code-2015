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

            int numberOfHouses_part01 = Part01(filename);
            int numberOfHouses_part02 = Part02(filename);

            System.Console.WriteLine("The number of houses Santa visited is \"{0}\".", numberOfHouses_part01);
            System.Console.WriteLine("The number of houses Santa visited is \"{0}\".", numberOfHouses_part02);
        }

        static int Part01(string inputFilename)
        {
            HashSet<Coordinate> houses = new HashSet<Coordinate>();
            int x = 0;
            int y = 0;

            // Add initial house (starting position)
            Coordinate initialHouse = new Coordinate(x, y);
            houses.Add(initialHouse);

            using (StreamReader fileReader = new StreamReader(inputFilename))
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

            return houses.Count;
        }

        static int Part02(string inputFilename)
        {
            HashSet<Coordinate> visitedHouseCoords = new HashSet<Coordinate>();
            Coordinate current_santa_coord = new Coordinate(0, 0);
            Coordinate current_robo_coord = new Coordinate(0, 0);
            bool isSanta = true;

            // Add initial house (starting position)
            visitedHouseCoords.Add(new Coordinate(0, 0));

            using (StreamReader fileReader = new StreamReader(inputFilename))
            {
                while (fileReader.Peek() > 0)
                {
                    char c = (char)fileReader.Read();

                    Coordinate coord;
                    if (isSanta)
                    {
                        coord = current_santa_coord;
                    }
                    else
                    {
                        coord = current_robo_coord;
                    }

                    switch (c)
                    {
                        case '<':
                            coord.X--;
                            break;
                        case '>':
                            coord.X++;
                            break;
                        case '^':
                            coord.Y--;
                            break;
                        case 'v':
                            coord.Y++;
                            break;
                        default:
                            throw new Exception("The land of 10,000 NOPES.");
                    }

                    if (!visitedHouseCoords.Contains(coord))
                    {
                        visitedHouseCoords.Add(coord);
                    }

                    isSanta = !isSanta;
                }

                fileReader.Close();
            }

            return visitedHouseCoords.Count;
        }
    }
}
