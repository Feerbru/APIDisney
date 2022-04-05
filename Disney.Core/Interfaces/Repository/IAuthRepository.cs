using System.Threading.Tasks;
using Disney.Core.Entities;

namespace Disney.Core.Interfaces.Repository
{
    public interface IAuthRepository : IRepository<User>
    {
        Task<User> GetLoginByCredentials(User user);

        Task<User> GetUserAndEmail(User user);
    }
}