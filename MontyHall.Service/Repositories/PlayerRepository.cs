using System;
using MontyHall.Service.Interfaces;
using MontyHall.Service.Models;

namespace MontyHall.Service.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private IGameRepository Game { get; set; }
        private readonly Random _random = new Random();

        public void Init(IGameRepository game)
        {
            Game = game;         
        }

        public void AutoPlay(bool shouldChangeChoice)
        {
            Game.WinCount = 0;

            for (var i = 0; i < Game?.GameModel?.Tries; i++)
            {
                var initialChoose = _random.Next(0, 3);

                Game.UserChoosesDoor(initialChoose);
                Game.SpeakerOpensDoor();

                var chosenDoor = shouldChangeChoice
                    ? Game.UserChoosesDoor(DoorState.Initial)
                    : Game.UserChoosesDoor(DoorState.Chosen);

                if (chosenDoor.Prize == GameModel.CAR)
                {
                    Game.WinCount++;
                }

                Game.ResetGame();
            }

            var strategyName = shouldChangeChoice
                ? "To change the initial choose upon request"
                : "Not to change the initial choose upon request";

            Console.WriteLine($"Session is finished. \n" +
                              $"Strategy: {strategyName} \n" +
                              $"You have played {Game.GameModel.Tries} games " +
                              $"wins: {Game.WinCount}." +
                              $"\nWin rate: {Game.WinRate}. \n");
        }
    }
}