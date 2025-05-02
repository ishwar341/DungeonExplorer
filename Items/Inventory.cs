using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer.Items
{
    public class Inventory
    {
        private const int MaxItems = 5; // Set inventory limit

        public List<Item> Items { get; private set; }

        public Inventory()
        {
            Items = new List<Item>();
        }

        public void AddItem(Item item) => Items.Add(item);

        public void RemoveItem(Item item) => Items.Remove(item);

        public Item FindItem(string name) => Items.FirstOrDefault(i => i.Name.ToLower() == name.ToLower());
    }
}