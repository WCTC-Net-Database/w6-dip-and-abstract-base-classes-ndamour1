using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public abstract class CharacterBase : ICharacter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public int Gold { get; set; }
        protected IRoom CurrentRoom;

        public CharacterBase() { }

        protected CharacterBase(string name, string type, int level, int hp, int gold, IRoom startingRoom)
        {
            Name = name;
            Type = type;
            Level = level;
            HP = hp;
            Gold = gold;
            CurrentRoom = startingRoom;
        }

        public void Attack(ICharacter target)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (this is Player player && player is IEquipment playerWithEquipment && !string.IsNullOrEmpty(playerWithEquipment.Equipment))
            {
                // Randomizer for lack of user input
                Random rnd = new Random();
                int equipment = rnd.Next(1, 3);

                if (equipment == 1)
                {
                    Console.WriteLine($"{Name} attacks {target.Name} with sword.");
                }
                else if (equipment == 2)
                {
                    Console.WriteLine($"{Name} attacks {target.Name} with shield.");
                }
            }
            else
            {
                Console.WriteLine($"{Name} attacks {target.Name}.");
            }
            Console.ResetColor();

            if (this is Player brokePlayer && target is ILootable targetWithTreasure && !string.IsNullOrEmpty(targetWithTreasure.Treasure))
            {
                Console.WriteLine($"{Name} takes {targetWithTreasure.Treasure} from {target.Name}");
                brokePlayer.Gold += 10; // Assuming each treasure is worth 10 gold
                targetWithTreasure.Treasure = null; // Treasure is taken
            }
            else if (this is Player playerWithGold && target is Player targetWithGold && targetWithGold.Gold > 0)
            {
                Console.WriteLine($"{Name} takes gold from {target.Name}");
                playerWithGold.Gold += targetWithGold.Gold;
                targetWithGold.Gold = 0; // Gold is taken
            }
        }

        public void Move()
        {
            Console.WriteLine($"{Name} moves.");
        }

        public void Enter(IRoom room)
        {
            CurrentRoom = room;
        }

        public virtual void MoveToRoom(string? direction = null)
        {
            IRoom nextRoom;
            switch (direction)
            {
                case "East":
                    nextRoom = CurrentRoom.East;
                    break;
                case "North":
                    nextRoom = CurrentRoom.North;
                    break;
                case "South":
                    nextRoom = CurrentRoom.South;
                    break;
                case "West":
                    nextRoom = CurrentRoom.West;
                    break;
                default:
                    nextRoom = null;
                    break;
            }

            if (nextRoom != null)
            {
                Enter(nextRoom);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Name} has entered {CurrentRoom.Name}.\n{CurrentRoom.Description}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("There is no door in that direction.");
                Console.ResetColor();
            }
        }

        // Abstract method for unique behavior to be implemented by derived classes
        public abstract void UniqueBehavior();
    }
}
