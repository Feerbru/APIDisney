using System.Threading.Tasks;
using Disney.Core.Entities;
using Disney.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Disney.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _token;

        public TokenController(ITokenService token)
        {
            _token = token;
        }
        
        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin login)
        {
            var validation = await _token.IsValidUser(login);   
            
            if (validation.Item1)
            {
                var token = _token.GenerateToken(validation.Item2);
                return Ok(new {token});
            }

            return NotFound();
            
        }

    }
}