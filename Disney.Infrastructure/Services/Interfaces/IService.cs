using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Infrastructure.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T dto);
        Task Update(T dto);
        Task Delete(int id);
    }
}