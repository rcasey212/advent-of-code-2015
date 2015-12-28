using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = args[0];
            int finalFloor = 0;
            int firstBasementPosition = 0;

            // 01a
            finalFloor = GetFinalFloorByLine(filename);
            System.Console.WriteLine("The final floor is: {0}", finalFloor);

            // 01b
            firstBasementPosition = FindFirstCharPositionInBasement(filename);
            System.Console.WriteLine("The first character position where Santa enters the basement is: {0}", firstBasementPosition);
        }

        static int FindFirstCharPositionInBasement(string filename)
        {
            int currentFloor = 0;
            int pos = 0;
            bool foundNegativeFloor = false;

            char[] buf = new char[1];

            using (StreamReader fileReader = new StreamReader(filename))
            {
                while ((fileReader.Peek() >= 0) && (false == foundNegativeFloor))
                {
                    char c = (char)fileReader.Read();
                    pos++;

                    switch (c)
                    {
                        case '(':
                            currentFloor++;
                            break;
                        case ')':
                            currentFloor--;
                            break;
                        default:
                            break;
                    }

                    if (currentFloor < 0)
                    {
                        foundNegativeFloor = true;
                    }
                }

                fileReader.Close();
            }

            if (foundNegativeFloor)
            {
                return pos;
            }
            else
            {
                return -1;
            }
        }

        static int GetFinalFloorByLine(string filename)
        {
            int ascendCount = 0;
            int descendCount = 0;

            using (StreamReader fileReader = new StreamReader(filename))
            {
                string line;

                while (null != (line = fileReader.ReadLine()))
                {
                    ascendCount += CountOccurrences('(', line);
                    descendCount += CountOccurrences(')', line);
                }

                fileReader.Close();
            }

            return (ascendCount - descendCount);
        }

        static int CountOccurrences(char c, string s)
        {
            int charCount = 0;

            foreach (char stringChar in s.ToCharArray())
            {
                if (stringChar == c)
                {
                    charCount++;
                }
            }

            return charCount;
        }
    }
}
