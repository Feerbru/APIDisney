using System.Threading.Tasks;
using Disney.Core.DTOs.UserDto;
using Disney.Core.Entities;

namespace Disney.Infrastructure.Services.Interfaces
{
    public interface IEmailService
    {
        Task CreatedAccountEmail(UserDto userDto);
    }
    
}