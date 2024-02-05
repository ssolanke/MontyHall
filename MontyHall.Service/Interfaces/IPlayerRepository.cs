namespace MontyHall.Service.Interfaces
{
    public interface IPlayerRepository
    {
        void AutoPlay(bool shouldChangeChoice);
        void Init(IGameRepository game);
    }
}