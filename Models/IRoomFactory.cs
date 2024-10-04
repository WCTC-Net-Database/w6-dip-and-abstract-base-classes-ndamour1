using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public interface IRoomFactory
    {
        IRoom CreateRoom(string roomType);
    }
}
