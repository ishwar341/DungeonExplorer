using Xunit;
using DungeonExplorer.Items;

public class InventoryTests
{
    [Fact]
    public void AddItem_IncreasesCount()
    {
        var inventory = new Inventory();
        inventory.AddItem(new Potion("Potion", 10));
        Assert.Single(inventory.Items);
    }

    [Fact]
    public void RemoveItem_DecreasesCount()
    {
        var inventory = new Inventory();
        var item = new Potion("Potion", 10);
        inventory.AddItem(item);
        inventory.RemoveItem(item);
        Assert.Empty(inventory.Items);
    }

    [Fact]
    public void FindItem_ReturnsCorrectItem()
    {
        var inventory = new Inventory();
        inventory.AddItem(new Potion("Healing", 10));
        var result = inventory.FindItem("healing");
        Assert.NotNull(result);
        Assert.Equal("Healing", result.Name);
    }
}
