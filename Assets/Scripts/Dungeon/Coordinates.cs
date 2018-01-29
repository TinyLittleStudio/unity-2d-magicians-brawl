using System;

namespace MagiciansBrawl.MBDungeon
{
    public struct Coordinates : IEquatable<Coordinates>
    {
        // X and Y Coordinates
        private int x, y;

        // Constructor
        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Returns X (readonly)
        public int X
        {
            get
            {
                return x;
            }

            set
            {
                this.x = value;
            }
        }

        // Returns Y (readonly)
        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                this.y = value;
            }
        }

        // Add
        public void Add(int x, int y)
        {
            this.x += x;
            this.y += y;
        }

        // Subtract
        public void Subtract(int x, int y)
        {
            this.x -= x;
            this.y -= y;
        }

        // Divide
        public void Devide(int x, int y)
        {
            this.x /= x;
            this.y /= y;
        }

        // Multiply
        public void Multiply(int x, int y)
        {
            this.x *= x;
            this.y *= y;
        }

        // Clone Coordinates
        public Coordinates Clone()
        {
            return new Coordinates(x, y);
        }

        // ToString
        public override string ToString()
        {
            return x + ", " + y;
        }

        // Equals
        public bool Equals(Coordinates coordinates)
        {
            return x == coordinates.x && y == coordinates.y;
        }

        // Equals with Offset
        public bool Equals(Coordinates coordinates, int x, int y)
        {
            return x + x == coordinates.x && y + y == coordinates.y;
        }
    }
}