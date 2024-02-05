using MontyHall.Service.Models;

namespace MontyHall.Service.Interfaces
{
    public interface IDoorRepository
    {
        DoorState DoorState { get; set; }
        string Prize { get; set; }
    }
}