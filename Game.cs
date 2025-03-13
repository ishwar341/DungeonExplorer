using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one player and one room
            player = new Player("Hero", 100);
            currentRoom = new Room("A dark and eerie dungeon chamber.", "Golden Key");
        }

        public void Start()
        {
            bool playing = true;
            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.WriteLine("Type 'look' to view the room, 'status' to check player info, 'pickup' to collect an item, or 'exit' to quit.");

            while (playing)
            {
                Console.Write("Enter command: ");
                string command = Console.ReadLine()?.Trim().ToLower();

                switch (command)
                {
                    case "look":
                        Console.WriteLine(currentRoom.GetDescription());
                        break;
                    case "status":
                        Console.WriteLine($"Player: {player.Name}");
                        Console.WriteLine($"Health: {player.Health}");
                        Console.WriteLine($"Inventory: {player.InventoryContents()}");
                        break;
                    case "pickup":
                        string item = currentRoom.GetItem();
                        if (!string.IsNullOrEmpty(item))
                        {
                            player.PickUpItem(item);
                        }
                        else
                        {
                            Console.WriteLine("There is nothing to pick up here.");
                        }
                        break;
                    case "exit":
                        playing = false;
                        Console.WriteLine("Exiting game...");
                        break;
                    default:
                        Console.WriteLine("Invalid command. Try again.");
                        break;
                }
            }
        }
    }
}