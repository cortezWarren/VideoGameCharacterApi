using VideoGameCharacterApi.Interfaces;
using VideoGameCharacterApi.DTOs;
using VideoGameCharacterApi.Data;
using Microsoft.EntityFrameworkCore;

namespace VideoGameCharacterApi.Services
{
    public class VideoGameCharacterService(AppDbContext context) : IVideoGameCharacterService
    {
        public async Task<List<CharacterResponse>> GetAllCharactersAsync()
            => await context.Characters.Select(c => new CharacterResponse
            {
                Name = c.Name,
                Game = c.Game,
                Role = c.Role
            }).ToListAsync();

        public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
        {
            var result = await context.Characters.Where(c => c.Id == id)
                .Select(c => new CharacterResponse
                {
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role
                })
                .FirstOrDefaultAsync();

            return result;
        }

        //public async Task<Character> AddCharacterAsync(Character character)
        //{
        //    Character newCharacter = new Character
        //    {
        //        Id = characters.Count + 1,
        //        Name = character.Name,
        //        Game = character.Game,
        //        Role = character.Role
        //    };
        //    characters.Add(newCharacter);

        //    return await Task.FromResult(newCharacter);
        //}
    }
}
