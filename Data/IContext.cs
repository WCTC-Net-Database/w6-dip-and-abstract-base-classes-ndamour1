using W6_assignment_template.Models;

namespace W6_assignment_template.Data
{
    public interface IContext
    {
        List<CharacterBase> Characters { get; set; }

        List<CharacterBase> GetCharacterList(string characterType);

        void AddCharacter(CharacterBase character);

        void UpdateCharacter(CharacterBase character);

        void DeleteCharacter(string characterName);
    }
}
