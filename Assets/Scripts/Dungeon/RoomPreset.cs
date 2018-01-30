using System.Collections.Generic;

namespace MagiciansBrawl.MBDungeon
{
    [System.Serializable]
    public class RoomPreset
    {
        // Room Preset Name
        public string name;

        // All Room Preset Objects in Room Preset
        public List<RoomPresetObject> roomPresetObjects = new List<RoomPresetObject>();

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
