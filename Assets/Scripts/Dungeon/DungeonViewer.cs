using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MagiciansBrawl.MBDungeon
{
    public class DungeonViewer : MonoBehaviour
    {
        // Padding between Rooms
        public static readonly int PADDING = 2;

        // Width and Height of a Room
        public static readonly int HEIGHT = 10, WIDTH = 16;

        // The Tilemap to Instantiate the Tiles on
        public Tilemap tilemap;

        // Unity Awake
        void Awake()
        {
            // Test-Dungeon Setup
            DungeonPreset dungeonPreset = new DungeonPreset
            {
                Length = 50,
                Theme = TilesManager.DEFAULT_THEME
            };

            Dungeon dungeon = new Dungeon(dungeonPreset);

            dungeon.Generate();

            VisualizeRooms(dungeon);
        }

        // Debug: Visualize Dungeon Structure with Tiles (Proper Rooms)
        private void VisualizeRooms(Dungeon dungeon)
        {
            // Return if Argument is Null
            if (dungeon == null)
            {
                return;
            }
            List<Room> rooms = dungeon.GetRooms();

            // Search TileSet
            DungeonPreset dungeonPreset = dungeon.GetDungeonPreset();

            string theme = dungeonPreset.Theme;

            List<TileSet> tileSets = TilesManager.GetTileSets(theme);

            TileSet tileSet = tileSets.Count > 0 ? tileSets[0] : null;

            if (tileSet == null)
            {
                Debug.LogError("Could Not Find TileSet Theme " + theme);
                return;
            }

            // Iterate all Rooms and Spawn Objects
            foreach (Room room in rooms)
            {
                // Create each Tile (Wall or Ground) of Room
                Coordinates coordinates = room.GetCoordinates();

                for (int y = 0; y < DungeonViewer.HEIGHT; y++)
                {
                    for (int x = 0; x < DungeonViewer.WIDTH; x++)
                    {
                        Vector3Int position = new Vector3Int(
                            (coordinates.X * (DungeonViewer.WIDTH + DungeonViewer.PADDING)) + x,
                            (coordinates.Y * (DungeonViewer.HEIGHT + DungeonViewer.PADDING)) + y,
                            0
                        );

                        bool isWall = x == 0 || y == 0 || x == DungeonViewer.WIDTH - 1 || y == DungeonViewer.HEIGHT - 1;

                        tilemap.SetTile(position, isWall ? tileSet.GetRandomTile(TileType.WALL) : tileSet.GetRandomTile(TileType.GROUND));
                    }
                }

                // Check and Create Doors
                Dictionary<Direction, Door> doors = room.GetDoors();

                foreach (Direction direction in doors.Keys)
                {
                    int x = 0;
                    int y = 0;

                    if (Direction.NORTH.Equals(direction))
                    {
                        x = DungeonViewer.WIDTH / 2;
                        y = 0;
                    }

                    if (Direction.EAST.Equals(direction))
                    {
                        x = DungeonViewer.WIDTH - 1;
                        y = DungeonViewer.HEIGHT / 2;
                    }

                    if (Direction.SOUTH.Equals(direction))
                    {
                        x = DungeonViewer.WIDTH / 2;
                        y = DungeonViewer.HEIGHT - 1;
                    }

                    if (Direction.WEST.Equals(direction))
                    {
                        x = 0;
                        y = DungeonViewer.HEIGHT / 2;
                    }

                    Vector3Int position = new Vector3Int(
                        (coordinates.X * (DungeonViewer.WIDTH + DungeonViewer.PADDING)) + x,
                        (coordinates.Y * (DungeonViewer.HEIGHT + DungeonViewer.PADDING)) + y,
                        0
                    );

                    tilemap.SetTile(position, tileSet.GetRandomTile(TileType.DOOR));

                    position = new Vector3Int(position.x + (direction.Y != 0 ? -1 : 0), position.y + (direction.X != 0 ? -1 : 0), position.z);

                    tilemap.SetTile(position, tileSet.GetRandomTile(TileType.DOOR));
                }
            }
        }

        // Debug: Visualize Dungeon Structure with Primitives (Cube)
        private void VisualizeDungeon(Dungeon dungeon)
        {
            // Return if Argument is Null
            if (dungeon == null)
            {
                return;
            }
            List<Room> rooms = dungeon.GetRooms();

            // Iterate all Rooms and Spawn Objects
            foreach (Room room in rooms)
            {
                Coordinates coordinates = room.GetCoordinates();

                // Spawn Primitive Cube
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject.transform.position = new Vector3(coordinates.X, 0, coordinates.Y);

                // Assign Colors for Room Types
                Color color = Color.black;

                if (RoomType.NORMAL.Equals(room.GetRoomType()))
                {
                    color = Color.gray;
                }
                else if (RoomType.START.Equals(room.GetRoomType()))
                {
                    color = Color.green;
                }
                else if (RoomType.END.Equals(room.GetRoomType()))
                {
                    color = Color.red;
                }
                Renderer renderer = gameObject.GetComponent<Renderer>();

                if (renderer != null)
                {
                    renderer.material.color = color;
                }
            }
        }
    }
}