using System;
using System.Linq;
using System.Threading.Tasks;
using Disney.Core.Entities;
using Disney.Core.Interfaces.Repository;
using Disney.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Disney.Infrastructure.Repository
{
    public class CharacterRepository : BaseRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Character> GetByIdAsync(int id)
        {
            return await Task.FromResult(_entities.Include("Movies").First(x => x.Id == id));
        }
    }
}