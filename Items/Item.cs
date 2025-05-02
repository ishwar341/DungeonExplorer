using DungeonExplorer.Entities;

namespace DungeonExplorer.Items
{
    public abstract class Item : ICollectible
    {
        public string Name { get; set; }

        protected Item(string name)
        {
            Name = name;
        }

        public abstract void Use(Player player);
    }
}