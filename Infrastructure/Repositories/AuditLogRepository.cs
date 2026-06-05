using Syrla.Domain.Entities;
using Syrla.Infrastructure.Data;
using Syrla.Api.Repositories.Interfaces;

namespace Syrla.Api.Repositories;

public class AuditLogRepository
    : Repository<AuditLog>,
      IAuditLogRepository
{
    public AuditLogRepository(AppDbContext context)
        : base(context)
    {
    }
}