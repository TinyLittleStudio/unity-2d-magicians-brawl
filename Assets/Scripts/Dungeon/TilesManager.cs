using System.Collections.Generic;
using UnityEngine;

namespace MagiciansBrawl.MBDungeon
{
    public class TilesManager : MonoBehaviour
    {
        // Default Theme Key
        public static readonly string DEFAULT_THEME = "default";

        // TileManager Instance
        private static TilesManager instance;

        // List of TileSets
        public List<TileSet> tileSets = new List<TileSet>();

        // Awake
        void Awake()
        {
            if (TilesManager.instance == null)
            {
                TilesManager.instance = this;
            }
            else
            {
                tileSets = TilesManager.instance.tileSets;
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

            foreach (TileSet tileSet in TilesManager.instance.tileSets)
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
