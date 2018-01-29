using System.Collections.Generic;

namespace MagiciansBrawl.MBDungeon
{
    public class Room
    {
        // Dungeon Reference
        private Dungeon dungeon;

        // Type of Room
        private RoomType roomType;

        // Doors and Corresponding Directions/Locations     
        private Dictionary<Direction, Door> doors = new Dictionary<Direction, Door>();

        // Coordinates
        private Coordinates coordinates;

        // Constructor
        private Room(Dungeon dungeon, RoomType roomType, Coordinates coordinates)
        {
            this.dungeon = dungeon;
            this.roomType = roomType;

            this.coordinates = coordinates;
        }

        // Get the Dungeon Reference
        public Dungeon GetDungeon()
        {
            return dungeon;
        }

        // Get the Type of Room
        public RoomType GetRoomType()
        {
            return roomType;
        }

        // Get the Doors with Directions as Dictionary
        public Dictionary<Direction, Door> GetDoors()
        {
            return doors;
        }

        // Get the Coordinates
        public Coordinates GetCoordinates()
        {
            return coordinates;
        }

        // Factory Create Method
        public static Room CreateRoom(Dungeon dungeon, RoomType roomType, Coordinates coordinates)
        {
            if (dungeon == null)
            {
                return null;
            }
            return new Room(dungeon, roomType, coordinates);
        }
    }
}
