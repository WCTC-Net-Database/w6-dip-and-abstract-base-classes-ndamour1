using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models.Rooms
{
    public class RoomBase : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IRoom North { get; set; }
        public IRoom South { get; set; }
        public IRoom East { get; set; }
        public IRoom West { get; set; }

        public void Enter(IRoom room) { }

        public RoomBase(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
