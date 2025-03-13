using System.Collections.Generic;
using System;

public class Player
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    private List<string> inventory;

    public Player(string name, int health)
    {
        Name = name;
        Health = health;
        inventory = new List<string>();
    }

    public void PickUpItem(string item)
    {
        if (!string.IsNullOrEmpty(item))
        {
            inventory.Add(item);
            Console.WriteLine($"{item} added to inventory.");
        }
        else
        {
            Console.WriteLine("Invalid item.");
        }
    }

    public string InventoryContents()
    {
        return inventory.Count > 0 ? string.Join(", ", inventory) : "No items";
    }
}