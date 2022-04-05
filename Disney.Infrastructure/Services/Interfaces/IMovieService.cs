using System.Collections.Generic;
using System.Threading.Tasks;
using Disney.Core.DTOs;
using Disney.Core.DTOs.MovieDtos;
using Disney.Core.QueryFilters;

namespace Disney.Infrastructure.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieOutDto>> GetAll(MovieQueryFilters filters);

        Task<MovieDto> GetById(int id);

        Task<MovieDto> Add(CreationMovieDto dto);
        
        Task Update(int id, CreationMovieDto dto);
        
        Task Delete(int id);
    }
}