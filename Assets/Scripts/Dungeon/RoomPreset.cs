using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagiciansBrawl.MBDungeon
{
    [Serializable]
    public class RoomPreset
    {
        // Room Preset Name
        [SerializeField]
        private string name;

        // All Room Preset Objects in Room Preset
        [SerializeField]
        private List<RoomPresetObject> roomPresetObjects = new List<RoomPresetObject>();

        // Constructor
        public RoomPreset(string name, params RoomPresetObject[] roomPresetObjects)
        {
            this.name = name;

            foreach (RoomPresetObject roomPresetObject in roomPresetObjects)
            {
                this.roomPresetObjects.Add(roomPresetObject);
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        // Get All Room Preset Objects
        public List<RoomPresetObject> GetRoomPresetObjects()
        {
            return roomPresetObjects;
        }
    }
}
