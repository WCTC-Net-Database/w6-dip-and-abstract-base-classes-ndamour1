### Week 6 Assignment: Dependency Inversion Principle (DIP) and Abstract Base Classes

---
### Objective

The goal of this assignment is to refactor the existing `ConsoleRPG` program to follow the Dependency Inversion Principle (DIP) and create abstract classes to encapsulate common properties and methods. You will:

1. Refactor your code to adhere to the Dependency Inversion Principle.
2. Create abstract classes to encapsulate common properties and methods.
3. Integrate these abstract classes into your existing codebase.

**Note**: If you are using this template, the code has already been updated but you may wish to copy the code into your existing project.

### Instructions

#### Part 1: Refactor for Dependency Inversion Principle (DIP)

1. **Understand DIP**:
   - **Definition**: High-level modules should not depend on low-level modules. Both should depend on abstractions.
   - **Goal**: Decouple your code to make it more flexible and easier to maintain.

2. **Identify Dependencies**:
   - Review your existing code to identify direct dependencies between classes.
   - Focus on areas where high-level modules (e.g., `GameEngine` depend on low-level modules (e.g., specific character classes).

3. **Create Abstractions**:
   - Define interfaces or abstract classes to represent the dependencies.
   - Ensure high-level modules depend on these abstractions rather than concrete implementations.

4. **Refactor Code**:
   - Update your code to use the new abstractions.
   - Ensure that concrete implementations are injected or provided through dependency injection.

#### Part 2: Create Abstract Classes for Common Properties and Methods

1. **Identify Common Properties and Methods**:
   - Review your existing character classes to identify common properties (e.g., `Name`, `HitPoints`, `Class`, `Level`, `CurrentRoom`).
   - Identify common methods (e.g., `MoveToRoom`, `PerformSpecialAction`).

2. **Create Abstract Classes**:
   - Define an abstract class (e.g., `CharacterBase`) to encapsulate the common properties and methods.
   - Ensure the abstract class provides a foundation for derived classes to build upon.

3. **Refactor Character Classes**:
   - Update your character classes to inherit from the new abstract class.
   - Move common properties and methods to the abstract class.
   - Implement any abstract methods in the derived classes.

### Example Abstract Class

```csharp
public abstract class CharacterBase : ICharacter
{
    public string Name { get; set; }
    public int HitPoints { get; set; }
    public string Class { get; set; }
    public int Level { get; set; }
    protected IRoom CurrentRoom { get; set; }

    protected CharacterBase(string name, int hitPoints, string characterClass, int level, IRoom startingRoom)
    {
        Name = name;
        HitPoints = hitPoints;
        Class = characterClass;
        Level = level;
        CurrentRoom = startingRoom;
        CurrentRoom.Enter();
    }

    public void MoveToRoom(IRoom room)
    {
        CurrentRoom = room;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{Name} has entered {CurrentRoom.Name}. {CurrentRoom.Description}");
        Console.ResetColor();
    }

    public abstract void PerformSpecialAction();
}
```

### Example Derived Class

```csharp
public class Warrior : CharacterBase
{
    public Warrior(string name, int hitPoints, int level, IRoom startingRoom)
        : base(name, hitPoints, "Warrior", level, startingRoom)
    {
    }

    public override void PerformSpecialAction()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{Name} performs a powerful attack!");
        Console.ResetColor();
    }
}
```

### Part 3: Integrate with Existing Codebase

1. **Update GameEngine**:
   - Modify the `GameEngine` to work with the new abstract classes and interfaces.
   - Ensure the `GameEngine` interacts with characters through abstractions.

2. **Test Your Code**:
   - Ensure your refactored code works correctly with the `GameEngine`.
   - Test the existing and new character classes to ensure they adhere to DIP.

3. **Demonstrate**:
   - Run the `GameEngine` with different characters to demonstrate the new structure in action.
   - Show how the `GameEngine` can interact with characters using the new abstractions.

### Stretch Goals

1. **Implement Additional Concrete Classes**:
   - Create additional classes using the common behaviors or properties and add your own special behaviors.
   - Refactor your code to use these new classes.

### Submission

- **Code Submission**:
  - Refactor the existing code and add your new classes in the provided project.
  - Ensure your project builds and runs successfully.
- **Documentation**:
  - Update the README file to include a brief description of each new abstraction and how they are used in the game.
- **GitHub**:
  - Push your changes to the GitHub Classroom repository.

### Rubric (100 Points Total)

| Criteria                                  | Points |
|-------------------------------------------|--------|
| **Refactoring for DIP**                   |        |
| Correctly identified and refactored dependencies to follow DIP. | 20     |
| Created appropriate abstractions (interfaces or abstract classes). | 10     |
| **Creating Abstract Classes**             |        |
| Created abstract classes for common properties and methods. | 15     |
| Refactored character classes to inherit from abstract classes. | 15     |
| Implemented abstract methods in derived classes. | 10     |
| **Integration and Testing**               |        |
| Successfully integrated new abstractions into the game logic. | 10     |
| Demonstrated that the program runs and behaves as expected. | 10     |
| **Code Quality and Documentation**        |        |
| Code is clean, well-documented, and follows best practices. | 10     |
| **Stretch Goal: Additional Abstract Classes or Dependency Injection** |        |
| Successfully implemented additional abstract classes or enhanced dependency injection. | +10    |

### Resources
- [Dependency Inversion Principle](https://www.freecodecamp.org/news/dependency-inversion-principle-solid-design-using-csharp/) - A guide to understanding and implementing DIP in C#.
- [Abstract Classes in C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members) - Official Microsoft documentation on abstract classes in C#.
- [Interfaces in C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/) - Official Microsoft documentation on using interfaces in C#.

#### SOLID Principles
- [SOLID Principles: A Guide for Developers](https://www.freecodecamp.org/news/solid-principles-every-developer-should-know/) - A detailed guide covering all the SOLID principles with examples.
- [Dependency Inversion Principle Explained](https://stackify.com/solid-design-dependency-inversion-principle/) - An easy-to-understand explanation of DIP with examples.
- [DIP in C#](https://www.tutorialsteacher.com/csharp/dependency-inversion-principle) - A tutorial focused on implementing DIP in C#.

### Tips
- These assignment instructions are intentionally high-level to give you flexibility in how you refactor your code.
- They may not align with your existing code, and the use of this template is optional.
- The instructions are written with your own implementation in mind, so feel free to adapt them to your specific needs.
- Using this template may help you structure your code and ensure you meet all the requirements.
 
---

### New Behavior Documentation
1. **GetCharacterList** - a new method in the IContext interface, that is then inherited by the DataContext class, that returns a list of characters that are from a deisgnated
2. **IRoom** - an interface used throughout the program to instantialize rooms for lists and for characters to enter and interact with one another.
3. **RoomBase** - a class that inherits from the IRoom interface that defines the properties of a room.
4. **Gold** - all characters now have a Gold int variable to keep track of their money (or lack thereof).
5. **CurrentRoom** - a variable in the CharacterBase class used to instantialize which room a character is currently in. This is inherited by all classes that inherit from CharacterBase.
6. **Attack** - the attack method is updated so that the player is able to use the weapons in their equipment against enemies. It also utilizes the ILootable interface below to loot dead goblins of their treasure.
7. **Enter** - a method in the CharacterBase class that initiates the process of characters entering another room in the building. This is inherited by all classes that inherit from CharacterBase.
8. **MoveToRoom** - a method in the CharacterBase class that determines which direction the door to another room a character wants to enter. This is inherited by all classes that inherit from CharacterBase.
9. **Look** - a method in the Player class that allows the player character to see into one of the rooms connected to the one they are currently in.
10. **IEquipment** - an interface in the Player class that it inherits from to instantialize the equipment the player character has on hand.
11. **Equipment** - a string variable in the Player class inherited from the IEquipment interface that stores the player character's equipment.
12. **ILootable** - an interface in the Goblin class that it inherits from to instantialize the idea that the player can loot the goblins of any treasure they have.
13. **Treasure** - a string variable in the Goblin and Ghost classes that instantiates an enemy's treasure (or lack thereof).
14. **UniqueBehavior** - the Ghost class has a unique behavior that allows them to phase through attacks.
15. **IRoomFactory** - an interface that instantiates the CreateRoom method.
16. **RoomBase** - a class that inherits the CreateRoom method from the IRoomFactory interfaces to create different types of rooms.
17. **GameEngine** - multiple private readonly variables are made to initialize the data context, lists of all or some of the characters, a list to put the various rooms in, and the characters themselves. They are then defined in the GameEngine constructor.
18. **Run** - the game will not run if the characters, rooms, or both are null. It also features an introduction of the "game" and variables pertaining to each of the various rooms.
19. **SetUpRooms** - a method in the GameEngine class that uses the RoomFactory interface to return an IRoom object of one of a requested type of room.
20. **ConfigureServices** - this method in the Program class has been updated to account for the room-based classes & interfaces.
