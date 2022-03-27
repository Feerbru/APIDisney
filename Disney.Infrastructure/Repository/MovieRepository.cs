using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disney.Core.Entities;
using Disney.Core.Interfaces.Repository;
using Disney.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Disney.Infrastructure.Repository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await Task.FromResult(_entities.Include("Characters").First(x => x.Id == id));
        }

        public async Task<IEnumerable<Movie>> GetAllInclude(string include)
        {
            return await _entities.Include(include).ToListAsync();
        }
    }
}