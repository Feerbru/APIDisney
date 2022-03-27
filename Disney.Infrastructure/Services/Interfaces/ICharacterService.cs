using System.Collections.Generic;
using System.Threading.Tasks;
using Disney.Core.DTOs;
using Disney.Core.DTOs.CharacterDtos;
using Disney.Core.Entities;
using Disney.Core.QueryFilters;

namespace Disney.Infrastructure.Services.Interfaces
{
    public interface ICharacterService
    {
        Task<IEnumerable<CharacterOutDto>> GetAll(CharacterQueryFilter filters);
        Task<CharacterDto> GetById(int id);
        Task<CharacterDto> Add(CreationCharacterDto dto);
        Task Update(int id, CreationCharacterDto dto);
        Task Delete(int id);
        
    }
}