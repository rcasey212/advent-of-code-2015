using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_day_03
{
    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        
        // override Equals and GetHashcode...
        public override bool Equals(object obj)
        {
            if (null == obj)
                return false;
            Coordinate rhs = obj as Coordinate;
            if (null == rhs)
                return false;
            return
                (
                X == rhs.X &&
                Y == rhs.Y
            );
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            hashCode ^= X.GetHashCode();
            hashCode ^= Y.GetHashCode();
            return hashCode;
        }

    }
}
