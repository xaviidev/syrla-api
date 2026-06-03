using Microsoft.EntityFrameworkCore;
using Syrla.Domain.Entities;

namespace Syrla.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
}
