using Xunit;
using DungeonExplorer.Entities;

public class PlayerTests
{
    [Fact]
    public void Player_Heals_Correctly()
    {
        var player = new Player("Hero", 50, 10);
        player.Heal(20);
        Assert.Equal(70, player.Health);
    }

    [Fact]
    public void Player_Boosts_Strength()
    {
        var player = new Player("Hero", 100, 10);
        player.BoostStrength(5);
        Assert.Equal(15, player.Strength);
    }

    [Fact]
    public void Player_Initializes_Correctly()
    {
        var player = new Player("Hero", 100, 10);
        Assert.Equal("Hero", player.Name);
        Assert.Equal(100, player.Health);
        Assert.Equal(10, player.Strength);
    }
}
