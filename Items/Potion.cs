using System;
using DungeonExplorer.Entities;

namespace DungeonExplorer.Items
{
    public class Potion : Item
    {
        public int HealAmount { get; set; }

        public Potion(string name, int healAmount) : base(name)
        {
            HealAmount = healAmount;
        }

        public override void Use(Player player)
        {
            player.Heal(HealAmount);
        }
    }
}