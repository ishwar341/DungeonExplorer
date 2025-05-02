using Xunit;
using DungeonExplorer.GameCore;
using DungeonExplorer.Items;

public class RoomTests
{
    [Fact]
    public void ConnectRoom_ShouldReturnConnectedRoom()
    {
        var room1 = new Room("A", "First room");
        var room2 = new Room("B", "Second room");
        room1.ConnectRoom("north", room2);
        var neighbor = room1.GetNeighbor("north");
        Assert.Equal("B", neighbor.Name);
    }

    [Fact]
    public void Room_AddsItemsCorrectly()
    {
        var room = new Room("Room", "Test room");
        room.Items.Add(new Weapon("Axe", 10));
        Assert.Single(room.Items);
    }
}
