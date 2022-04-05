using System.Threading.Tasks;
using Disney.Core.Entities;

namespace Disney.Infrastructure.Services.Interfaces
{
    public interface ITokenService
    {
        Task<(bool, User)> IsValidUser(UserLogin login);

        string GenerateToken(User user);
    }
}