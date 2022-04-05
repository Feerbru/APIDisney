using System.Threading.Tasks;
using Disney.Core.DTOs.UserDto;
using Disney.Core.Entities;

namespace Disney.Infrastructure.Services.Interfaces
{
    public interface IAuthService 
    {
        Task<User> GetLoginByCredentials(UserLogin login);

        Task Register(UserDto userDto);
        
        Task<bool> GetUserAndEmail(UserDto userDto);
    }
}