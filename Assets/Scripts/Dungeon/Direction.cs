using System.Collections.Generic;

namespace MagiciansBrawl.MBDungeon
{
    public class Direction
    {
        // North (Up)
        public static readonly Direction NORTH = new Direction(0, -1);

        // East (Right)
        public static readonly Direction EAST = new Direction(1, 0);

        // South (Down)
        public static readonly Direction SOUTH = new Direction(0, 1);

        // West (Left)
        public static readonly Direction WEST = new Direction(-1, 0);

        // Direction Values
        public static IEnumerable<Direction> Values
        {
            get
            {
                yield return NORTH;

                yield return EAST;

                yield return SOUTH;

                yield return WEST;
            }
        }

        // Direction by Value
        private readonly int x, y;

        // Constructor
        private Direction(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Returns X (read only)
        public int X
        {
            get
            {
                return x;
            }
        }

        // Returns Y (read only)
        public int Y
        {
            get
            {
                return y;
            }
        }
    }
}
