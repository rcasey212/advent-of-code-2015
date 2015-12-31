using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc_day_05
{
    public class Program
    {
        static readonly string[] MUST_CONTAIN_3_OF_THESE = new string[] { "a", "e", "i", "o", "u" };
        static readonly string[] MUST_NOT_CONTAIN_ANY_OF_THESE = new string[] { "ab", "cd", "pq", "xy" };


        static void Main(string[] args)
        {
            string filename = args[0];
            List<int> niceLinesA = null;
            List<int> naughtyLinesA = null;
            List<int> niceLinesB = null;
            List<int> naughtyLinesB = null;

            Day_05_Part_A(filename, out niceLinesA, out naughtyLinesA);
            Day_05_Part_B(filename, out niceLinesB, out naughtyLinesB);

            System.Console.WriteLine("Part A: Out of \"{0}\" lines, \"{1}\" are nice strings.",
                niceLinesA.Count() + naughtyLinesA.Count(), niceLinesA.Count());
            System.Console.WriteLine("Part B: Out of \"{0}\" lines, \"{1}\" are nice strings.",
                niceLinesB.Count() + naughtyLinesB.Count(), niceLinesB.Count());
        }

        public static bool IsNiceStringA(string input)
        {
            if (HasAtLeastOneContiguousDuplicateLetter(input) &&
                        0 == GetCountOfMatchedStrings(input, MUST_NOT_CONTAIN_ANY_OF_THESE) &&
                        2 < GetCountOfMatchedStrings(input, MUST_CONTAIN_3_OF_THESE))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsNiceStringB(string input)
        {
            if (HasRepeatingLetterWithOneLetterBetween(input) &&
                HasRepeatingNonOverlappingCharPair(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void Day_05_Part_A(string filename, out List<int> niceLines, out List<int> naughtyLines)
        {
            niceLines = new List<int>();
            naughtyLines = new List<int>();
            int currLineNumber = 0;

            using (StreamReader fileReader = new StreamReader(filename))
            {
                string line;
                while (null != (line = fileReader.ReadLine()))
                {
                    if (IsNiceStringA(line))
                    {
                        niceLines.Add(currLineNumber);
                    }
                    else
                    {
                        naughtyLines.Add(currLineNumber);
                    }

                    currLineNumber++;
                }
            }
        }

        private static void Day_05_Part_B(string filename, out List<int> niceLines, out List<int> naughtyLines)
        {
            niceLines = new List<int>();
            naughtyLines = new List<int>();
            int currLineNumber = 0;

            using (StreamReader fileReader = new StreamReader(filename))
            {
                string line;
                while (null != (line = fileReader.ReadLine()))
                {
                    if (IsNiceStringB(line))
                    {
                        niceLines.Add(currLineNumber);
                    }
                    else
                    {
                        naughtyLines.Add(currLineNumber);
                    }

                    currLineNumber++;
                }
            }
        }

        private static bool HasAtLeastOneContiguousDuplicateLetter(string input)
        {
            char prevChar = '\0';
            bool hasDuplicate = false;

            foreach (char c in input.ToCharArray())
            {
                if (prevChar == c)
                {
                    hasDuplicate = true;
                    break;
                }
                else
                {
                    prevChar = c;
                }
            }

            return hasDuplicate;
        }

        private static int GetCountOfMatchedStrings(string input, string[] toMatch)
        {
            int count = 0;
            string source = input;

            foreach (string s in toMatch)
            {
                count += (input.Length - source.Replace(s, "").Length) / s.Length;
            }

            return count;
        }

        private static bool HasRepeatingLetterWithOneLetterBetween(string input)
        {
            bool success = false;

            char twoAgo = '\0';
            char oneAgo = '\0';

            foreach (char c in input.ToCharArray())
            {
                if (twoAgo == c)
                {
                    success = true;
                    break;
                }
                else
                {
                    twoAgo = oneAgo;
                    oneAgo = c;
                }
            }

            return success;
        }

        private static bool HasRepeatingNonOverlappingCharPair(string input)
        {
            if (input.Length < 4)
            {
                return false;
            }

            char oneAgo = '\0';
            List<string> pairsToSearch = new List<string>();

            foreach (char c in input.ToCharArray())
            {
                if ('\0' != oneAgo)
                {
                    pairsToSearch.Add(string.Format("{0}{1}", oneAgo, c));
                }

                oneAgo = c;
            }

            if (GetCountOfMatchedStrings(input, pairsToSearch.ToArray()) > 1)
            {
                return true;
            }
        }
    }
}
