using System.Collections.Generic;
using System.Threading.Tasks;
using Disney.Core.Entities;

namespace Disney.Core.Interfaces.Repository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<Movie> GetByIdAsync(int id);

        Task<IEnumerable<Movie>> GetAllInclude(string include);
    }
}