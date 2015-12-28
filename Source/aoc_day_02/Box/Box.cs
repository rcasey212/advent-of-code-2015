using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_day_02.Box
{
    internal class Box
    {
        private int[] dimensions = new int[3];

        internal int Length {
            get
            { return dimensions[(int)BoxDimension.Length]; }
            set
            { dimensions[(int)BoxDimension.Length] = value; }
        }
        internal int Width
        {
            get
            { return dimensions[(int)BoxDimension.Width]; }
            set
            { dimensions[(int)BoxDimension.Width] = value; }
        }
        internal int Height
        {
            get
            { return dimensions[(int)BoxDimension.Height]; }
            set
            { dimensions[(int)BoxDimension.Height] = value; }
        }

        internal static bool TryParse(string dimension, out Box result)
        {
            bool isValidResult = false;
            result = new Box();

            try
            {
                string[] boxDim = dimension.Split(new char[] { 'x' });

                if (3 != boxDim.Length)
                {
                    throw new Exception("Param needs three ints, separated by x.");
                }

                result.Length = int.Parse(boxDim[0]);
                result.Width = int.Parse(boxDim[1]);
                result.Height = int.Parse(boxDim[2]);

                isValidResult = true;
            }
            catch (Exception)
            {
                result = null;
                isValidResult = false;
            }

            return isValidResult;
        }

        internal int CalcNeededWrappingPaper()
        {
            int[] areas = new int[3]
            {
                (Length * Width), (Width * Height), (Height * Length)
            };
            int minArea = areas.Min();

            int totalSurfaceArea = 2 * areas.Sum();
            int totalNeededWrappingPaperArea = totalSurfaceArea + minArea;

            return totalNeededWrappingPaperArea;
        }

        internal int CalcNeededRibbonLength()
        {
            Array.Sort(dimensions);
            return (2 * dimensions[0]) + (2 * dimensions[1]) + dimensions.Aggregate(1, (a, b) => a * b);
        }
    }
}
