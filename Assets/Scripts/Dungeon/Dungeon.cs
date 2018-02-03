using System.Collections.Generic;
using UnityEngine;

namespace MagiciansBrawl.MBDungeon
{
    public class Dungeon
    {
        // Current Dungeon Instance
        private static Dungeon instance;

        // Dungeon Preset (Contains all Required Information to Generate a Dungeon)
        private DungeonPreset dungeonPreset;

        // All Rooms
        private List<Room> rooms;

        // Constructor
        public Dungeon(DungeonPreset dungeonPreset)
        {
            this.dungeonPreset = dungeonPreset;
        }

        // Generate Dungeon
        public void Generate()
        {
            // Initialize Values
            rooms = new List<Room>();

            // Generate Start Room
            Room start = Room.CreateRoom(this, RoomType.START, new Coordinates(0, 0));
            rooms.Add(start);

            int progress = dungeonPreset.Length - 1;

            float compare = 0.2f;

            // Generate Rooms
            for (int i = 0; i < progress; i++)
            {
                float percentage = (((float)i) / ((float)progress));

                compare = Mathf.Lerp(0.2f, 0.01f, percentage);

                Coordinates coordinates = GetNewCoordinates(false);

                Room[] neighbors = GetNeighbors(coordinates);

                if (neighbors.Length > 1 && Random.value > compare)
                {
                    int iterations = 0;

                    do
                    {
                        coordinates = GetNewCoordinates(true);

                        neighbors = GetNeighbors(coordinates);

                        iterations++;
                    } while (neighbors.Length > 1 && iterations < 100);
                }
                Room room = Room.CreateRoom(this, i < progress - 1 ? RoomType.NORMAL : RoomType.END, coordinates);
                rooms.Add(room);
            }

            // Generate Doors
            foreach (Room room in rooms)
            {
                foreach (Direction direction in Direction.Values)
                {
                    Coordinates coordinates = room.GetCoordinates().Clone();
                    coordinates.Add(direction.X, direction.Y);

                    Room temp = GetRoomAt(coordinates);

                    if (temp != null)
                    {
                        room.GetDoors().Add(direction, Door.CreateDoor(room, temp));
                    }
                }
            }

            // Set Current Dungeon Instance
            Dungeon.instance = this;
        }

        // Returns Coordinates for a Room to Create
        private Coordinates GetNewCoordinates(bool isAlternative)
        {
            // Define and Initialize Variables
            int x = 0, y = 0;
            int index = 0;

            int iterations = 0;

            Coordinates coordinates = new Coordinates();

            // Try for Empty Space
            do
            {
                iterations = 0;

                Room temp = rooms[index];

                // Try to find Coordinates with less Neighbors
                do
                {
                    index = Mathf.RoundToInt(Random.value * (rooms.Count - 1));

                    temp = rooms[index];

                    iterations++;
                } while (isAlternative && GetNeighbors(temp.GetCoordinates()).Length > 1 && iterations < 100);

                x = temp.GetCoordinates().X;
                y = temp.GetCoordinates().Y;

                bool isUpOrDown = (Random.value > 0.5f);
                bool isPositive = (Random.value > 0.5f);

                if (isUpOrDown)
                {
                    if (isPositive)
                    {
                        y += 1;
                    }
                    else
                    {
                        y -= 1;
                    }
                }
                else
                {
                    if (isPositive)
                    {
                        x += 1;
                    }
                    else
                    {
                        x -= 1;
                    }
                }
                coordinates = new Coordinates(x, y);
            } while (GetRoomAt(coordinates) != null);

            return coordinates;
        }

        // Returns Room At Coordinates
        public Room GetRoomAt(Coordinates coordinates)
        {
            foreach (Room room in rooms)
            {
                Coordinates temp = room.GetCoordinates();

                if (temp.Equals(coordinates))
                {
                    return room;
                }
            }
            return null;
        }

        // Returns Rooms Around Coordinates
        public Room[] GetNeighbors(Coordinates coordinates)
        {
            List<Room> result = new List<Room>();

            foreach (Room room in rooms)
            {
                Coordinates temp = room.GetCoordinates();

                if (temp.Equals(coordinates, 0, -1))
                {
                    result.Add(room);
                }

                if (temp.Equals(coordinates, -1, 0))
                {
                    result.Add(room);
                }

                if (temp.Equals(coordinates, 0, 1))
                {
                    result.Add(room);
                }

                if (temp.Equals(coordinates, 1, 0))
                {
                    result.Add(room);
                }
            }
            return result.ToArray();
        }

        // Returns the Rooms as List
        public List<Room> GetRooms()
        {
            return rooms;
        }

        // Returns the Dungeon Size (Room Count)
        public int Size
        {
            get
            {
                return dungeonPreset.Length;
            }
        }

        // Get Dungeon Preset
        public DungeonPreset GetDungeonPreset()
        {
            return dungeonPreset;
        }

        // Get Dungeon Room Index by World Position
        public static Coordinates GetGameObjectCoordinates(GameObject gameObject)
        {
            Transform transform = gameObject.transform;

            float x = transform.position.x;
            float y = transform.position.y;

            x = Mathf.FloorToInt(x / (float)((Room.WIDTH + Room.PADDING) * Tiles.TILE_SIZE));
            y = Mathf.FloorToInt(y / (float)((Room.HEIGHT + Room.PADDING) * Tiles.TILE_SIZE));

            return new Coordinates((int)x, (int)y);
        }

        // Get Current Dungeon Instance
        public static Dungeon GetDungeonInstance()
        {
            return Dungeon.instance;
        }
    }
}
