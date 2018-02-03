using System.Collections.Generic;
using UnityEngine;

namespace MagiciansBrawl.MBDungeon
{
    public class RoomHandler : MonoBehaviour
    {
        // Room Handler Instance
        private static RoomHandler instance;

        // Available Room Presets
        [Header("Room Settings")]
        [SerializeField]
        private List<RoomPreset> roomPresets = new List<RoomPreset>();

        // Awake
        private void Awake()
        {
            // Set Instance or Destroy
            if (RoomHandler.instance == null)
            {
                RoomHandler.instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        // Get All Room Presets
        public static List<RoomPreset> GetRoomPresets()
        {
            List<RoomPreset> roomPresets = RoomHandler.instance.roomPresets;
            return roomPresets;
        }

        // Get Random Room Preset
        public static RoomPreset GetRandomRoomPreset()
        {
            List<RoomPreset> roomPresets = RoomHandler.instance.roomPresets;
            return roomPresets[Random.Range(0, roomPresets.Count)];
        }
    }
}
