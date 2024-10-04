using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models.Rooms
{
    public class RoomFactory : IRoomFactory
    {
        public IRoom CreateRoom(string roomType)
        {
            switch (roomType)
            {
                default:
                    return new RoomBase("Big Empty Room", "It sure is big and empty.");
                case "Bathroom":
                    return new RoomBase("Bathroom", "There is a toilet, a sink with a mirror, and a bathtub.");
                case "Bedroom":
                    return new RoomBase("Bedroom", "There is a two-person bed, a nightstand, and a dresser with a mirror.");
                case "Foyer":
                    return new RoomBase("Foyer", "It is the entrance hall of the building.");
                case "Kitchen":
                    return new RoomBase("Kitchen", "There is a dining table with chairs, as well as cabinets and counters stocked with food.");
                case "Living Room":
                    return new RoomBase("Living Room", "There is a fireplace and chairs for people to sit on.");

            };
        }
    }
}
