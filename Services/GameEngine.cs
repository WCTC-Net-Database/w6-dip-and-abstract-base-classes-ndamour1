using W6_assignment_template.Data;
using W6_assignment_template.Interfaces;
using W6_assignment_template.Models;

namespace W6_assignment_template.Services
{
    public class GameEngine
    {
        // Initalization of context
        private readonly IContext _context;
        private readonly List<CharacterBase> _characters;
        private readonly IRoomFactory _roomFactory;
        private readonly List<CharacterBase> _players;
        private readonly List<CharacterBase> _goblins;
        private readonly List<CharacterBase> _ghosts;

        // Characters
        private readonly CharacterBase _player;
        private readonly CharacterBase _goblin1;
        private readonly CharacterBase _goblin2;
        private readonly CharacterBase _goblin3;
        private readonly CharacterBase _ghost;

        public GameEngine(IContext context, IRoomFactory roomFactory)
        {
            // Context
            _context = context;
            _characters = context.Characters;
            _roomFactory = roomFactory;
            _players = context.GetCharacterList("Player");
            _goblins = context.GetCharacterList("Goblin");
            _ghosts = context.GetCharacterList("Ghost");

            // Characters
            _player = _players[0];
            _goblin1 = _goblins[0];
            _goblin2 = _goblins[1];
            _goblin3 = _goblins[2];
            _ghost = _ghosts[1];
        }

        public void Run()
        {
            if (_characters == null && _roomFactory == null)
            {
                Console.WriteLine("Failed to initialize game characters & rooms.");
                return;
            }
            else if (_characters == null)
            {
                Console.WriteLine("Failed to initialize game characters.");
                return;
            }
            else if (_roomFactory == null)
            {
                Console.WriteLine("Failed to initialize game rooms.");
                return;
            }

            var foyer = SetUpRooms("Foyer");
            var livingRoom = SetUpRooms("Living Room");
            var kitchen = SetUpRooms("Kitchen");
            var bathroom = SetUpRooms("Bathroom");
            var bedroom = SetUpRooms("Bedroom");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome to the game.\nYou are {_player.Name} in a cottage full of goblins and ghosts.\nRid this residence of these fiends.\n");
            Console.ResetColor();

            _player.Enter(foyer);
            Console.WriteLine($"Player Gold: {_player.Gold}");
            _goblin1.Enter(livingRoom);
            _goblin2.Enter(kitchen);
            _goblin3.Enter(kitchen);
            _ghost.Enter(bedroom);

            // Turn 1
            _player.MoveToRoom("North");
            _goblin1.Move();
            _goblin2.Move();
            _goblin3.Move();
            _ghost.MoveToRoom("West");
            _ghost.Enter(bathroom);

            // Turn 2
            _player.Move();
            _goblin1.Attack(_player);
            _goblin2.Move();
            _goblin3.Move();
            _ghost.MoveToRoom("South");
            _ghost.Enter(kitchen);

            // Turn 3
            _player.Attack(_goblin1);
            Console.WriteLine($"Player Gold: {_player.Gold}");
            _goblin2.Attack(_ghost);
            _ghost.UniqueBehavior();
            _goblin3.Attack(_ghost);
            _ghost.UniqueBehavior();
        }

        public IRoom SetUpRooms(string roomType)
        {
            var foyer = _roomFactory.CreateRoom("Foyer");
            var livingRoom = _roomFactory.CreateRoom("Living Room");
            var kitchen = _roomFactory.CreateRoom("Kitchen");
            var bathroom = _roomFactory.CreateRoom("Bathroom");
            var bedroom = _roomFactory.CreateRoom("Bedroom");

            // Linking of rooms
            foyer.North = livingRoom;
            livingRoom.North = bathroom;
            livingRoom.South = foyer;
            livingRoom.West = kitchen;
            kitchen.East = livingRoom;
            kitchen.North = bathroom;
            bathroom.South = kitchen;
            bathroom.East = bedroom;
            bedroom.West = bathroom;
            bedroom.South = livingRoom;

            switch (roomType)
            {
                default:
                    return new RoomBase("Big Empty Room", "It sure is big and empty.");
                case "Bathroom":
                    return bathroom;
                case "Bedroom":
                    return bedroom;
                case "Foyer":
                    return foyer;
                case "Kicthen":
                    return kitchen;
                case "Living Room":
                    return livingRoom;
            }
        }
    }
}
