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
        public async Task<ActionResult<CharacterResponse>> GetCharacterByIdAsync(int id)
        {
            var character = await videoGameCharacterService.GetCharacterByIdAsync(id);

            return character is null ? NotFound("Character is not found") : Ok(character);
        }

        //[HttpPost]
        //public async Task<ActionResult<Character>> AddCharacterAsync(Character character)
        //    => Ok(await videoGameCharacterService.AddCharacterAsync(character));
        
    }
}
