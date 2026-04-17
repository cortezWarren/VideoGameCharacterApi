using VideoGameCharacterApi.DTOs;

namespace VideoGameCharacterApi.Interfaces
{
    public interface IVideoGameCharacterService
    {
        Task<List<CharacterResponse>> GetAllCharactersAsync();
        Task<CharacterResponse?> GetCharacterByIdAsync(int id);
        //Task<Character> AddCharacterAsync(Character character);
        //Task<bool> UpdateCharacterAsync(int id, Character character);
        //Task<bool> DeleteCharacterAsync(int id);
    }
}
