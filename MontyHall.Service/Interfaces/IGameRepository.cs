using MontyHall.Service.Models;

namespace MontyHall.Service.Interfaces
{
    public interface IGameRepository
    {
        GameModel? GameModel { get; }

        int WinCount { get; set; }

        double WinRate { get; }

        DoorModel UserChoosesDoor(int doorIndex);

        DoorModel UserChoosesDoor(DoorState doorState);

        int IndexOfDoor(DoorModel door);

        DoorModel SpeakerOpensDoor();

        void ResetGame();

        void Init(GameModel gameModel);
    }
}