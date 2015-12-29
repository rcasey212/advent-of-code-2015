using System;
using System.Collections.Generic;
using System.IO;


namespace aoc_day_03
{
    public static class Runner
    {
        public static int Day_03_Part_A(string filename)
        {
            HashSet<Coordinate> houses = new HashSet<Coordinate>();
            Coordinate santa_coord = new Coordinate(0, 0);

            // Add initial house (starting position)
            houses.Add(new Coordinate(0, 0));

            using (StreamReader fileReader = new StreamReader(filename))
            {
                while (fileReader.Peek() > 0)
                {
                    char c = (char)fileReader.Read();

                    ParseDirectionCharacter(c, ref santa_coord);

                    Coordinate newCoord = new Coordinate(santa_coord.X, santa_coord.Y);
                    if (!houses.Contains(newCoord))
                    {
                        houses.Add(newCoord);
                    }
                }

                fileReader.Close();
            }

            return houses.Count;
        }

        public static int Day_03_Part_B(string filename)
        {
            HashSet<Coordinate> houses = new HashSet<Coordinate>();
            Coordinate santa_coord = new Coordinate(0, 0);
            Coordinate robo_coord = new Coordinate(0, 0);
            bool isSanta = true;

            // Add initial house (starting position)
            houses.Add(new Coordinate(0, 0));

            using (StreamReader fileReader = new StreamReader(filename))
            {
                while (fileReader.Peek() > 0)
                {
                    char c = (char)fileReader.Read();

                    Coordinate current_coord;
                    if (isSanta)
                    { current_coord = santa_coord; }
                    else
                    { current_coord = robo_coord; }
                    ParseDirectionCharacter(c, ref current_coord);

                    Coordinate newCoord = new Coordinate(current_coord.X, current_coord.Y);
                    if (!houses.Contains(newCoord))
                    {
                        houses.Add(newCoord);
                    }

                    // Flip the isSanta bit
                    isSanta = !isSanta;
                }

                fileReader.Close();
            }

            return houses.Count;
        }

        private static void ParseDirectionCharacter(char c, ref Coordinate coord)
        {
            switch (c)
            {
                case '<':
                    coord.X--;
                    break;
                case '>':
                    coord.X++;
                    break;
                case '^':
                    coord.Y++;
                    break;
                case 'v':
                    coord.Y--;
                    break;
                default:
                    throw new Exception("The input file contains an invalid character.");
            }
        }
    }
}
