using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Disney.Core.Entities;
using Disney.Core.Interfaces.Repository;
using Disney.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Disney.Infrastructure.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<T> _entities;
        
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<T> GetById(int id, string include)
        {
            return await _entities
                .Include(include)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> Add(T entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}