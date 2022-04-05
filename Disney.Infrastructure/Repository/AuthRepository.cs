using System.Threading.Tasks;
using Disney.Core.Entities;
using Disney.Core.Interfaces.Repository;
using Disney.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Disney.Infrastructure.Repository
{
    public class AuthRepository : BaseRepository<User>, IAuthRepository
    {
        public AuthRepository(ApplicationDbContext context): base(context) { }    
        
        public async Task<User> GetLoginByCredentials(User user)
        {
            return await _entities.FirstOrDefaultAsync(x => Equals(x.Username, user.Username));
        }
        
        public async Task<User> GetUserAndEmail(User user)
        {
            return await _entities.FirstOrDefaultAsync(x =>
                Equals(x.Username, user.Username) && Equals(x.Email, user.Email));
        }
    }
}