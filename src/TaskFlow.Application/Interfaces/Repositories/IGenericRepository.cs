using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T>
        where T : BaseEntity
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
