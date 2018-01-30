using System.Collections.Generic;
using UnityEngine;

namespace MagiciansBrawl.MBDungeon
{
    public class TileHandler : MonoBehaviour
    {
        // Default Theme Key
        public static readonly string DEFAULT_THEME = "default";

        // Tile Manager Instance
        private static TileHandler instance;

        // List of TileSets
        public List<TileSet> tileSets = new List<TileSet>();

        // Awake
        void Awake()
        {
            if (TileHandler.instance == null)
            {
                TileHandler.instance = this;
            }
            else
            {
                tileSets = TileHandler.instance.tileSets;
            }
        }

        // Get TileSets by Theme as List
        public static List<TileSet> GetTileSets(string theme)
        {
            List<TileSet> result = new List<TileSet>();

            if (theme == null || theme.Length == 0)
            {
                return result;
            }
            theme = theme.ToLower();

            foreach (TileSet tileSet in TileHandler.instance.tileSets)
            {
                string temp = tileSet.theme.ToLower();

                if (temp.Equals(theme))
                {
                    result.Add(tileSet);
                }
            }
            return result;
        }
    }
}
