

using System.Collections.Generic;

namespace MontyHall.Service.Models
{
    public class GameModel
    {
        public const string GOAT = "GOAT";
        public const string CAR = "CAR";

        public bool Switch { get; set; }
        public long Tries { get; set; }

        public List<DoorModel> Doors { get; set; }

        public GameModel()
        {
            Doors = new List<DoorModel>
            {
                 new DoorModel (GOAT, DoorState.Initial ),
                 new DoorModel (GOAT, DoorState.Initial ),
                 new DoorModel (CAR, DoorState.Initial ),
            };
            // write code for suffle. Doors.re();
        }

    }
}
