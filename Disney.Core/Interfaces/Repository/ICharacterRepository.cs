using System.Threading.Tasks;
using Disney.Core.Entities;

namespace Disney.Core.Interfaces.Repository
{
    public interface ICharacterRepository : IRepository<Character>
    {
        Task<Character> GetByIdAsync(int id);
    }
}