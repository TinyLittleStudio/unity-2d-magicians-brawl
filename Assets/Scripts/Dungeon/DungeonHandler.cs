using System.Collections.Generic;
using UnityEngine;
using MagiciansBrawl.MBUtils;

namespace MagiciansBrawl.MBDungeon
{
    public class DungeonHandler : MonoBehaviour
    {
        // Global Dungeon Handler Instance
        private static DungeonHandler instance;

        // Current Dungeon Instance
        private Dungeon dungeon;

        // Last Player Coordinates / Room
        private Coordinates lastPlayerCoordinates;

        // The Player Object
        [Header("Player Game Object")]
        [SerializeField]
        private GameObject player;

        // The Player Object
        [Header("Game Content Object")]
        [SerializeField]
        private GameObject content;

        // All Instantiated GameObjects (Temporary Storage)
        private List<GameObject> gameObjects = new List<GameObject>();

        // Awake
        private void Awake()
        {
            // Set Instance or Destroy
            if (DungeonHandler.instance == null)
            {
                DungeonHandler.instance = this;
            }
            else
            {
                Destroy(this);
            }

            // Search Player
            if (player == null)
            {
                this.player = GameObject.FindGameObjectWithTag(Settings.Tags.PLAYER);

                if (player == null)
                {
                    Debug.LogError("Could Not Find Player");
                }
            }
        }

        // Late Update
        private void LateUpdate()
        {
            // Check for Dungeon Instance
            Dungeon temp = Dungeon.GetDungeonInstance();

            if (temp != null && (dungeon == null || dungeon != temp))
            {
                dungeon = temp;
            }

            if (dungeon == null)
            {
                return;
            }

            // Update Player Position Index (Trigger Room Spawning Mechanic)
            Coordinates coordinates = Dungeon.GetGameObjectCoordinates(player);

            if (!coordinates.Equals(lastPlayerCoordinates))
            {
                OnLeaveRoom(dungeon.GetRoomAt(lastPlayerCoordinates));

                lastPlayerCoordinates = coordinates;

                OnEnterRoom(dungeon.GetRoomAt(lastPlayerCoordinates));
            }
        }

        // On Player Leave Room 
        public void OnLeaveRoom(Room room)
        {
            // Check for Room
            if (room == null)
            {
                return;
            }
        }

        // On Player Enter Room
        public void OnEnterRoom(Room room)
        {
            // Check for Room
            if (room == null)
            {
                return;
            }

            // Generate Room Interior
            RoomPreset roomPreset = room.GetRoomPreset();

            if (roomPreset == null)
            {
                return;
            }
            List<RoomPresetObject> roomPresetObjects = roomPreset.GetRoomPresetObjects();

            // Clear GameObjects
            foreach (GameObject gameObject in gameObjects)
            {
                Destroy(gameObject);
            }
            gameObjects.Clear();

            Coordinates coordinates = room.GetCoordinates();

            int offsetx = coordinates.X * ((Room.WIDTH + Room.PADDING) * Tiles.TILE_SIZE);
            int offsety = coordinates.Y * ((Room.HEIGHT + Room.PADDING) * Tiles.TILE_SIZE);

            foreach (RoomPresetObject roomPresetObject in roomPresetObjects)
            {
                GameObject gameObject = roomPresetObject.GetGameObject();

                if (gameObject == null)
                {
                    continue;
                }
                int x = roomPresetObject.GetX() * Tiles.TILE_SIZE + offsetx;
                int y = roomPresetObject.GetY() * Tiles.TILE_SIZE + offsety;

                GameObject temp = Instantiate(gameObject, new Vector3(x, y, Settings.Depths.OBJECT_DEPTH), Quaternion.identity);

                // Assign to Container (if possible)
                if (temp != null && content != null)
                {
                    temp.transform.SetParent(content.transform);
                }
                gameObjects.Add(temp);
            }
        }
    }
}
