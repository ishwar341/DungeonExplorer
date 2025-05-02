using System;
using System.Linq;
using DungeonExplorer.Entities;
using DungeonExplorer.GameCore;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private bool isPlaying;

        public Game()
        {
            player = new Player("Hero", 100, 10);
            var map = new GameMap();
            currentRoom = map.StartRoom;
        }

        public void Start()
        {
            isPlaying = true;
            Console.WriteLine("Welcome to Dungeon Explorer!");

            while (isPlaying)
            {
                Console.WriteLine("\n" + currentRoom.GetDetails());
                Console.Write("Enter command: ");
                string input = Console.ReadLine()?.Trim().ToLower();

                HandleCommand(input);
            }
        }

        private void HandleCommand(string input)
        {
            var parts = input.Split(' ');
            var command = parts[0];
            var argument = string.Join(" ", parts.Skip(1));

            switch (command)
            {
                case "look":
                    Console.WriteLine(currentRoom.GetDetails());
                    break;
                case "status":
                    Console.WriteLine($"Player: {player.Name}\nHealth: {player.Health}\nStrength: {player.Strength}");
                    Console.WriteLine("Inventory: " + string.Join(", ", player.Inventory.Items.Select(i => i.Name)));
                    break;
                case "pickup":
                    var item = currentRoom.Items.FirstOrDefault(i => i.Name.ToLower() == argument);
                    if (item != null)
                    {
                        player.Inventory.AddItem(item);
                        currentRoom.Items.Remove(item);
                        Console.WriteLine($"{item.Name} picked up.");
                    }
                    else Console.WriteLine("Item not found.");
                    break;
                case "use":
                    player.UseItem(argument);
                    break;
                case "attack":
                    if (currentRoom.Monster != null)
                    {
                        player.Attack(currentRoom.Monster);
                        if (currentRoom.Monster.Health <= 0)
                        {
                            Console.WriteLine($"{currentRoom.Monster.Name} has been defeated!");
                            currentRoom.Monster = null;
                        }
                        else
                        {
                            currentRoom.Monster.Attack(player);
                            if (player.Health <= 0)
                            {
                                Console.WriteLine("You were defeated! Game Over.");
                                isPlaying = false;
                            }
                        }
                    }
                    else Console.WriteLine("There is no monster here.");
                    break;
                case "move":
                    var nextRoom = currentRoom.GetNeighbor(argument);
                    if (nextRoom != null) currentRoom = nextRoom;
                    else Console.WriteLine("You can't move that way.");
                    break;
                case "exit":
                    isPlaying = false;
                    Console.WriteLine("Thanks for playing!");
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}