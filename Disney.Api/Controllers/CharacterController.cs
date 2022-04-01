using System.Threading.Tasks;
using AutoMapper;
using Disney.Core.DTOs;
using Disney.Core.DTOs.CharacterDtos;
using Disney.Core.QueryFilters;
using Disney.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Disney.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _service;

        public CharacterController(ICharacterService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CharacterQueryFilter filter)
        {
            var entity = await _service.GetAll(filter);
            return Ok(entity);
        }

        [HttpGet("{id}", Name = "GetCharacter")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await _service.GetById(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm]CreationCharacterDto creationCharacterDto)
        {
            var dto = await _service.Add(creationCharacterDto);
            return new CreatedAtRouteResult("GetCharacter" , new {id = dto.Id}, dto);

        }

        [HttpPut]
        public async Task<IActionResult> Put(int id,[FromForm] CreationCharacterDto creationCharacterDto)
        {
            await _service.Update(id,creationCharacterDto);
            return Ok(new {message = "Actualizado con exito"});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             await _service.Delete(id);
            return Ok("entity delete");
        }
    }
}