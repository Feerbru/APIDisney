using System.Collections.Generic;
using System.Threading.Tasks;
using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.QueryFilters;

namespace Disney.Infrastructure.Services.Interfaces
{
    public interface ICharacterService 
    {
        Task<IEnumerable<CharacterDTO>> GetAll(CharacterQueryFilter filters);
        Task<CharacterOutDTO> GetById(int id);
        Task<CharacterOutDTO> Add(CreationCharacterDto dto);
        Task Update(int id, CreationCharacterDto dto);
        Task Delete(int id);
        
    }
}