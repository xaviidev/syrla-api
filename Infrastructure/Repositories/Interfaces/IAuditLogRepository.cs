using Syrla.Domain.Entities;
using Syrla.Api.Repositories.Interfaces;

namespace Syrla.Api.Repositories.Interfaces;

public interface IAuditLogRepository : IRepository<AuditLog>
{
}