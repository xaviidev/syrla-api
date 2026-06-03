using Microsoft.EntityFrameworkCore;
using Syrla.Infrastructure.Data;
using Syrla.Domain.Entities;
using Syrla.Api.Repositories.Interfaces;

namespace Syrla.Api.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbSet
            .FirstOrDefaultAsync(x => x.Email == email);
    }
}
