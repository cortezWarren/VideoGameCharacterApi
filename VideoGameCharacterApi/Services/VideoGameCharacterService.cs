using VideoGameCharacterApi.Interfaces;
using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.DTOs;

namespace VideoGameCharacterApi.Services
{
    public class VideoGameCharacterService : IVideoGameCharacterService
    {
        static List<Character> characters = new List<Character> {
            new Character { Id = 1, Name = "Mario", Game = "Super Mario Bros.", Role = "Hero"},
            new Character { Id = 2, Name = "Ash", Game = "Pokemon Sun and Moon", Role = "Trainer"},
            new Character { Id = 3, Name = "Sonic", Game = "Sonic Dash", Role = "Hero"},
            new Character { Id = 4, Name = "Zelda", Game = "The Legends of Zelda", Role = "Princess"}
        };
        public async Task<List<Character>> GetAllCharactersAsync()
            => await Task.FromResult(characters);

        public async Task<Character?> GetCharacterByIdAsync(int id)
        {
           var result = characters.FirstOrDefault(character => character.Id == id);
           return await Task.FromResult(result);
        }

        public async Task<Character> AddCharacterAsync(Character character)
        {
            Character newCharacter = new Character
            {
                Id = characters.Count + 1,
                Name = character.Name,
                Game = character.Game,
                Role = character.Role
            };
            characters.Add(newCharacter);

            return await Task.FromResult(newCharacter);
        }
    }
}
