using System.Threading.Tasks;
using Disney.Core.DTOs.MovieDtos;
using Disney.Core.QueryFilters;
using Disney.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Disney.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService service)
        {
            _movieService = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] MovieQueryFilters filter)
        {
            var entity = await _movieService.GetAll(filter);
            return Ok(entity);
        }
        
        [HttpGet("{id}", Name = "GetMovie")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await _movieService.GetById(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm]CreationMovieDto creationMovieDto)
        {
            var dto = await _movieService.Add(creationMovieDto);
            return new CreatedAtRouteResult("GetMovie" , new {id = dto.Id}, dto);

        }

        [HttpPut]
        public async Task<IActionResult> Put(int id,[FromForm] CreationMovieDto creationMovieDto)
        {
            await _movieService.Update(id,creationMovieDto);
            return Ok(new {message = "Actualizado con exito"});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _movieService.Delete(id);
            return Ok("entity delete");
        }
    }
}