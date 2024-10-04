using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public class Goblin : CharacterBase, ILootable
    {
        public string Treasure { get; set; }

        public Goblin() : base() { }

        public Goblin(string name, string type, int level, int hp, int gold, string treasure, IRoom startingRoom)
            : base(name, type, level, hp, gold, startingRoom)
        {
            Treasure = treasure;
        }

        public override void UniqueBehavior()
        {
            throw new NotImplementedException();
        }
    }

    public interface ILootable
    {
        string Treasure { get; set; }
    }
}
