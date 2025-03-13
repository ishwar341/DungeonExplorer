
using DungeonExplorer;

public class Room
{
    private string description;
    private string item;

    public Room(string description, string item)
    {
        this.description = description;
        this.item = item;
    }

    public string GetDescription()
    {
        return description + (string.IsNullOrEmpty(item) ? "" : $" There is a {item} here.");
    }

    public string GetItem()
    {
        string temp = item;
        item = ""; // Remove item from room after pickup
        return temp;
    }
}


