namespace DungeonExplorer.Entities
{
    public abstract class Creature : IDamageable
    {
        public string Name { get; set; }
        public int Health { get; protected set; }
        public int Strength { get; protected set; }

        public Creature(string name, int health, int strength)
        {
            Name = name;
            Health = health;
            Strength = strength;
        }

        public virtual void TakeDamage(int amount)
        {
            Health -= amount;
        }

        public abstract void Attack(Creature target);
    }
}