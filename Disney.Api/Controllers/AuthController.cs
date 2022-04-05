using System.Threading.Tasks;
using Disney.Core.DTOs.UserDto;
using Disney.Core.Entities;
using Disney.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Disney.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _token;
        private readonly IAuthService _service;
        private readonly IEmailService _email;

        public AuthController(ITokenService token, 
                              IAuthService service,
                              IEmailService email)
        {
            _token = token;
            _service = service;
            _email = email;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin login)
        {
            var validation = await _token.IsValidUser(login);
            
            if (validation.Item1)
            {
                var token = _token.GenerateToken(validation.Item2);
                return Ok(new {token});
            }

            return NotFound(new {message = "Usuario o contraseña incorrecta"});
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Post(UserDto userDto)
        {
            if ( await _service.GetUserAndEmail(userDto))
            {
                return Ok(new {Message = "usuario o email existentes"});
            }
            
            await _service.Register(userDto);
            
            await _email.CreatedAccountEmail(userDto);
            
            return Ok(new {message = "Usuario Agregado!"});
        }

    }
}