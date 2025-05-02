using System;
using System.Linq;
using DungeonExplorer.Items;

namespace DungeonExplorer.Entities
{
    public class Player : Creature
    {
        public Inventory Inventory { get; private set; }

        public Player(string name, int health, int strength) : base(name, health, strength)
        {
            Inventory = new Inventory();
        }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} attacks {target.Name} with strength {Strength}!");
            target.TakeDamage(Strength);
        }

        public void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"{Name} healed by {amount}. Current health: {Health}");
        }

        public void BoostStrength(int amount)
        {
            Strength += amount;
            Console.WriteLine($"{Name} gained {amount} strength. Current strength: {Strength}");
        }

        public void UseItem(string itemName)
        {
            var item = Inventory.FindItem(itemName);
            if (item != null)
            {
                item.Use(this);
                Inventory.RemoveItem(item);
            }
            else
            {
                Console.WriteLine("Item not found in inventory.");
            }
        }
    }
}