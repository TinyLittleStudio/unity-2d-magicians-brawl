using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MagiciansBrawl.MBDungeon
{
    [Serializable]
    public class TileSet
    {
        // Theme Key
        [SerializeField]
        private string theme;

        // Tiles 
        [SerializeField]
        private List<Tiles> tiles;

        // Constructor
        public TileSet(string theme, List<Tiles> tiles)
        {
            this.theme = theme;
            this.tiles = tiles;
        }

        // Get Theme
        public string GetTheme()
        {
            return theme;
        }

        // Get Tiles by TileType
        public List<Tiles> GetTiles(TileType tileType)
        {
            List<Tiles> result = new List<Tiles>();

            foreach (Tiles tiles in this.tiles)
            {
                if (tileType.Equals(tiles.GetTileType()))
                {
                    result.Add(tiles);
                }
            }
            return result;
        }

        // Get Random Tiles
        public Tiles GetRandomTiles(TileType tileType)
        {
            List<Tiles> tilesList = GetTiles(tileType);

            Tiles tiles = tilesList[UnityEngine.Random.Range(0, tilesList.Count)];

            return tiles;
        }

        // Get Random Tile
        public TileBase GetRandomTile(TileType tileType)
        {
            Tiles tiles = GetRandomTiles(tileType);

            return tiles.GetRandomTile();
        }
    }
}
