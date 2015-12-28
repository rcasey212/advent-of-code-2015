using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using aoc_day_02.Box;

namespace aoc_day_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = args[0];
            int totalWrappingPaperNeeded = 0;
            int totalRibbonLengthNeeded = 0;

            using (StreamReader fileReader = new StreamReader(filename))
            {
                string line;

                while (null != (line = fileReader.ReadLine()))
                {
                    aoc_day_02.Box.Box b;
                    aoc_day_02.Box.Box.TryParse(line, out b);
                    totalWrappingPaperNeeded += b.CalcNeededWrappingPaper();
                    totalRibbonLengthNeeded += b.CalcNeededRibbonLength();
                }

                fileReader.Close();
            }

            System.Console.WriteLine("The total square feet of wrapping paper needed is \"{0}sq.ft.\"", totalWrappingPaperNeeded);
            System.Console.WriteLine("The total length of ribbon to order is \"{0}ft.\"", totalRibbonLengthNeeded);
        }
    }
}
