using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterSevice _characterSevice;

        //Step 1: type "ctor" (shrortcut to add the base of this constructor)
        //Step 2: Select the parameter "characterSevice" and execute "Ctrl + .", then "Create and assing field 'characterService'"
        //More: in minute 58:00 https://youtu.be/9zJn3a7L1uE?si=dspVn97kBvfQzNKu&t=3497
        public CharacterController(ICharacterSevice characterSevice)
        {
            _characterSevice = characterSevice;
        }

        [HttpGet("GetAll")]
        // [Route("GetAll")]
        public async Task<ActionResult<List<Character>>> Get() 
        {
            return Ok(await _characterSevice.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetSingle(int id) 
        {
            return Ok(await _characterSevice.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character newCharacter) 
        {
            return Ok(await _characterSevice.AddCharacter(newCharacter));            
        }
    }
}