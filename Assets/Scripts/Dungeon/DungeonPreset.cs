namespace MagiciansBrawl.MBDungeon
{
    public struct DungeonPreset
    {
        // Dungeon Room Amount
        private int length;

        // Dungeon Tile Theme Key
        private string theme;

        // Returns and Defines the Length (Room Amount)
        public int Length
        {
            get; set;
        }

        // Returns and Defines the Theme Key (Tiles Theme)
        public string Theme
        {
            get; set;
        }
    }
}