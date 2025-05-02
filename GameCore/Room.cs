using System;
using System.Collections.Generic;
using System.Linq;
using DungeonExplorer.Entities;
using DungeonExplorer.Items;

namespace DungeonExplorer.GameCore
{
    public class Room
    {
        public string Name { get; }
        public string Description { get; }
        public List<Item> Items { get; }
        public Monster Monster { get; set; }
        public Dictionary<string, Room> Neighbors { get; }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
            Neighbors = new Dictionary<string, Room>();
        }

        public void ConnectRoom(string direction, Room neighbor)
        {
            Neighbors[direction.ToLower()] = neighbor;
        }

        public Room GetNeighbor(string direction)
        {
            return Neighbors.TryGetValue(direction.ToLower(), out var room) ? room : null;
        }

        public string GetDetails()
        {
            var itemList = Items.Any() ? $"Items: {string.Join(", ", Items.Select(i => i.Name))}" : "No items.";
            var monsterInfo = Monster != null ? $"Monster: {Monster.Name}" : "No monsters.";
            var exits = $"Exits: {string.Join(", ", Neighbors.Keys)}";
            return $"{Name} - {Description}\n{itemList}\n{monsterInfo}\n{exits}";
        }
    }
}