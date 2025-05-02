using Xunit;
using DungeonExplorer.Entities;

public class MonsterTests
{
    [Fact]
    public void Monster_TakesDamageCorrectly()
    {
        var goblin = new Monster("Goblin", 30, 5);
        goblin.TakeDamage(10);
        Assert.Equal(20, goblin.Health);
    }
}
