using System;

namespace DungeonExplorer.Entities
{
    public class Monster : Creature
    {
        public Monster(string name, int health, int strength) : base(name, health, strength) { }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} attacks {target.Name} with {Strength} damage!");
            target.TakeDamage(Strength);
        }
    }
}