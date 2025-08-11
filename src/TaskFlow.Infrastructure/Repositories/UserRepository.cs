using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Domain.Entities;
using TaskFlow.Infrastructure.Data;

namespace TaskFlow.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly TaskFlowDbContext _context;

        public UserRepository(TaskFlowDbContext context)
            : base(context)
        {
            this._context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
