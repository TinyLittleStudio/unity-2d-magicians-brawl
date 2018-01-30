using UnityEngine;

namespace MagiciansBrawl.MBDungeon
{
    [System.Serializable]
    public class RoomPresetObject
    {
        // GameObject to Instantiate
        public GameObject gameObject;

        // Coordinates to Instantiate
        public int x;
        public int y;

        // Constructor
        public RoomPresetObject(GameObject gameObject, int x, int y)
        {
            this.gameObject = gameObject;
            this.x = x;
            this.y = y;
        }

        // Get the GameObject to Instantiate
        public GameObject GetGameObject()
        {
            return gameObject;
        }

        // Get the X Coordinate to Instantiate
        public int GetX()
        {
            return x;
        }

        // Get the Y Coordinate to Instantiate
        public int GetY()
        {
            return y;
        }
    }
}
