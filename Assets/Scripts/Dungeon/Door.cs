namespace MagiciansBrawl.MBDungeon
{
    public class Door
    {
        // The Rooms the Door is Pointing "From" and "To"
        private Room from, to;

        // Constructor
        private Door(Room from, Room to)
        {
            this.from = from;
            this.to = to;
        }

        // Set "From"-Room
        public void SetFrom(Room from)
        {
            this.from = from;
        }

        // Get "From"-Room
        public Room GetFrom()
        {
            return from;
        }

        // Set "To"-Room
        public void SetTo(Room to)
        {
            this.to = to;
        }

        // Get "To"-Room
        public Room GetTo()
        {
            return to;
        }

        // Factory Create Method
        public static Door CreateDoor(Room from, Room to)
        {
            if (from == null || to == null)
            {
                return null;
            }
            return new Door(from, to);
        }
    }
}