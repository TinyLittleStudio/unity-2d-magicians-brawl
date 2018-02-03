using System.Collections.Generic;

namespace MagiciansBrawl.MBDungeon
{
    public class Room
    {
        // Padding between Rooms
        public static readonly int PADDING = 2;

        // Width and Height of a Room
        public static readonly int HEIGHT = 10, WIDTH = 16;

        // Dungeon Reference
        private Dungeon dungeon;

        // Type of Room
        private RoomType roomType;

        // Doors and Corresponding Directions/Locations     
        private Dictionary<Direction, Door> doors = new Dictionary<Direction, Door>();

        // Coordinates
        private Coordinates coordinates;

        // RoomPreset 
        private RoomPreset roomPreset;

        // Constructor
        private Room(Dungeon dungeon, RoomType roomType, Coordinates coordinates, RoomPreset roomPreset)
        {
            this.dungeon = dungeon;
            this.roomType = roomType;

            this.coordinates = coordinates;

            this.roomPreset = roomPreset;
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

        // Get the RoomPreset
        public RoomPreset GetRoomPreset()
        {
            return roomPreset;
        }

        // Factory Create Method
        public static Room CreateRoom(Dungeon dungeon, RoomType roomType, Coordinates coordinates)
        {
            return CreateRoom(dungeon, roomType, coordinates, RoomHandler.GetRandomRoomPreset());
        }

        // Factory Create Method
        public static Room CreateRoom(Dungeon dungeon, RoomType roomType, Coordinates coordinates, RoomPreset roomPreset)
        {
            if (dungeon == null)
            {
                return null;
            }
            return new Room(dungeon, roomType, coordinates, roomPreset);
        }
    }
}
