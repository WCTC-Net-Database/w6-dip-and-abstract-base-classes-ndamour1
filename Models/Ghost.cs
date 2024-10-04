using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public class Ghost : CharacterBase, IFlyable
    {
        public string Treasure { get; set; }

        public Ghost() : base() { }

        public Ghost(string name, string type, int level, int hp, int gold, string treasure, IRoom startingRoom)
            : base(name, type, level, hp, gold, startingRoom)
        {
            Treasure = treasure;
        }

        public void Fly()
        {
            Console.WriteLine($"{Name} flies rapidly through the air.");
        }

        public override void UniqueBehavior()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Name}'s intangibility saves them from the attack.");
            Console.ResetColor();
        }
    }
}
