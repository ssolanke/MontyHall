using System;
using System.Linq;
using MontyHall.Service.Interfaces;
using MontyHall.Service.Models;

namespace MontyHall.Service.Repositories
{
    public class GameRepository : IGameRepository
    {
        public GameModel? GameModel { get; private set; }

        public int WinCount { get; set; }

        public double WinRate => (double)WinCount / GameModel.Tries;

        public void Init(GameModel gameModel)
        {
            GameModel = gameModel;
        }

        public DoorModel UserChoosesDoor(int doorIndex)
        {
            if (doorIndex < 0 || doorIndex > 2)
            {
                throw new InvalidOperationException($"Door {doorIndex} doesn't exist.");
            }

            if (GameModel.Doors[doorIndex].State == DoorState.Opened)
            {
                throw new InvalidOperationException("Door is already opened by the speaker.");
            }

            GameModel.Doors[doorIndex].State = DoorState.Chosen;
            return GameModel.Doors[doorIndex];
        }

        public DoorModel UserChoosesDoor(DoorState state)
        {
            var door = GameModel.Doors.First(x => x.State == state);

            door.State = DoorState.Chosen;

            return door;
        }

        public int IndexOfDoor(DoorModel door)
        {
            return GameModel.Doors.IndexOf(door);
        }

        public DoorModel SpeakerOpensDoor()
        {
            var door = GameModel.Doors.First(x => x.Prize == GameModel.GOAT && x.State != DoorState.Chosen);

            door.State = DoorState.Opened;

            return door;
        }

        public void ResetGame()
        {
            GameModel.Doors.ForEach(x => x.State = DoorState.Initial);

            GameModel.Doors = GameModel.Doors.OrderBy(x => new Random().Next()).ToList();
        }
    }
}
