using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public class Player : CharacterBase, IEquipment
    {
        public string Equipment { get; set; }

        public Player() : base() { }

        public Player(string name, string type, int level, int hp, int gold, string equipment, IRoom startingRoom)
            : base(name, type, level, hp, gold, startingRoom)
        {
            Equipment = equipment;
        }

        public void Look(IRoom subject)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} looks and sees {subject.Name}.");
            Console.ResetColor();
        }

        public override void UniqueBehavior()
        {
            throw new NotImplementedException();
        }
    }

    public interface IEquipment
    {
        string Equipment { get; set; }
    }
}
