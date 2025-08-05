using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Domain.Entities;
using TaskFlow.Infrastructure.Data;

namespace TaskFlow.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        private readonly TaskFlowDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(TaskFlowDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            var item = await _dbSet.FindAsync(entity.Id);
            if (item == null)
                throw new InvalidOperationException("Item not found.");

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var item = await _dbSet.FindAsync(entity.Id);
            if (item == null)
                throw new InvalidOperationException("Item not found.");

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
