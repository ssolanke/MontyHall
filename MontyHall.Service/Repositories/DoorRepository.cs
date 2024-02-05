using MontyHall.Service.Interfaces;
using MontyHall.Service.Models;

namespace MontyHall.Service.Repositories
{
    public class DoorRepository : IDoorRepository
    {
        public DoorState DoorState { get; set; }
        public string Prize { get; set; }
    }
}