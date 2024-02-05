using FluentAssertions;
using MontyHall.Service.Interfaces;
using MontyHall.Service.Models;
using MontyHall.Service.Repositories;
using Xunit;

namespace MontyHall.Test
{
    public class UnitTest1
    {
        
        [Fact]
        public void MontyHallProblemTest_ChangeDoor_Success()
        {
            IGameRepository game = new GameRepository();
            var player = new PlayerRepository();
            game.Init(new GameModel { Tries = 1000000, Switch = true });
            player.Init(game);
            player.AutoPlay(shouldChangeChoice: true);

            game.WinRate.Should().BeGreaterThan(0.66d);
        }

        
        [Fact]
        public void MontyHallProblemTest_DoNotChangeDoor_Success()
        {
            IGameRepository game = new GameRepository();
            IPlayerRepository player = new PlayerRepository();
            game.Init(new GameModel { Tries = 1000000, Switch = false });
            player.Init(game);
            player.AutoPlay(shouldChangeChoice: false);

            game.WinRate.Should().BeGreaterThan(0.33d);
        }
        
    }
}
