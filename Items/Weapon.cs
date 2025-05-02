using System;
using DungeonExplorer.Entities;

namespace DungeonExplorer.Items
{
    public class Weapon : Item
    {
        public int DamageBoost { get; set; }

        public Weapon(string name, int damageBoost) : base(name)
        {
            DamageBoost = damageBoost;
        }

        public override void Use(Player player)
        {
            player.BoostStrength(DamageBoost);
        }
    }
}