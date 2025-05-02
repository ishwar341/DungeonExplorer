using DungeonExplorer.Entities;
using DungeonExplorer.Items;

namespace DungeonExplorer.GameCore
{
    public class GameMap
    {
        public Room StartRoom { get; private set; }

        public GameMap()
        {
            var room1 = new Room("Entrance Hall", "The dusty entry to the dungeon.");
            var room2 = new Room("Armory", "Rusted weapons line the walls.");
            var room3 = new Room("Treasure Room", "The glow of gold lights the chamber.");
            var room4 = new Room("Puzzle Chamber", "Strange symbols glow on the floor.");
            var room5 = new Room("Boss Room", "A terrifying presence fills the air.");

            room1.ConnectRoom("east", room2);
            room2.ConnectRoom("west", room1);
            room2.ConnectRoom("north", room3);
            room3.ConnectRoom("south", room2);
            room3.ConnectRoom("east", room4);
            room4.ConnectRoom("west", room3);
            room4.ConnectRoom("north", room5);
            room5.ConnectRoom("south", room4);


            room2.Items.Add(new Weapon("Rusty Sword", 5));
            room3.Items.Add(new Potion("Healing Elixir", 20));
            room3.Monster = new Monster("Goblin", 30, 5);

            StartRoom = room1;
        }
    }
}