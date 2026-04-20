using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.DTOs;
using VideoGameCharacterApi.Interfaces;

namespace VideoGameCharacterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameCharactersController(IVideoGameCharacterService videoGameCharacterService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<CharacterResponse>>> GetVideoGameCharacters()
            => Ok(await videoGameCharacterService.GetAllCharactersAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponse>> GetCharacter(int id)
        {
            var character = await videoGameCharacterService.GetCharacterByIdAsync(id);

            return character is null ? NotFound("Character is not found") : Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<CharacterResponse>> AddCharacterAsync(CreateCharacterRequest character)
        {
            var newCharacter = await videoGameCharacterService.AddCharacterAsync(character);
            return CreatedAtAction(nameof(GetCharacter), new {id = newCharacter.Id}, newCharacter);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCharacter(int id, UpdateCharacterRequest character) 
        {
            var updated = await videoGameCharacterService.UpdateCharacterAsync(id, character);
            return updated ? NoContent() : NotFound("Character with given Id not found");
        }
    }
}
