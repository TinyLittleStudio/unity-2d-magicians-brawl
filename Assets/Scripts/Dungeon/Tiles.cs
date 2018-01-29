using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MagiciansBrawl.MBDungeon
{
    [System.Serializable]
    public class Tiles
    {
        // TileType
        public TileType tileType;

        // List of all Tiles for TileType
        public List<TileBase> tiles;

        // Add Tile
        public void Add(TileBase tileBase)
        {
            if (tileBase == null)
            {
                return;
            }
            tiles.Add(tileBase);
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