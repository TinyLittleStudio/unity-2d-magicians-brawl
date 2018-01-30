using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MagiciansBrawl.MBDungeon
{
    [System.Serializable]
    public class Tiles
    {
        // Tile Size
        public static readonly int TILE_SIZE = 1;

        // Tiles Object Name
        public string name;

        // TileType
        public TileType tileType;

        // List of all Tiles for TileType
        public List<TileBase> tiles;

        // Constructor
        public Tiles(string name, TileType tileType, List<TileBase> tiles)
        {
            this.name = name;
            this.tileType = tileType;
            this.tiles = tiles;
        }

        // Add Tile
        public void Add(TileBase tileBase)
        {
            if (tileBase == null)
            {
                return;
            }
            tiles.Add(tileBase);
        }

        // Returns the Tiles Object Name
        public string Name
        {
            get
            {
                return name;
            }
        }

        // Get TileType
        public TileType GetTileType()
        {
            return tileType;
        }

        // Get Tiles as List
        public List<TileBase> GetTiles()
        {
            return tiles;
        }

        // Get Random Tile
        public TileBase GetRandomTile()
        {
            return tiles != null ? tiles[Random.Range(0, tiles.Count)] : null;
        }
    }
}