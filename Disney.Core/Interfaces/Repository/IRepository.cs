using System.Collections.Generic;
using System.Threading.Tasks;
using Disney.Core.Entities;

namespace Disney.Core.Interfaces.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        
        Task<T> GetById(int id);
        
        Task<T> GetById(int id, string include);
        
        Task<T> Add(T entity);
        
        Task Update(T entity);
        
        Task Delete(int id);
        
    }
}