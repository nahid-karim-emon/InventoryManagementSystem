using IMS.Core.Common;
using IMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IMS.Core.CoreInterface.IReadRepository;

namespace IMS.Infrastructure.Core
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity>
    where TEntity : class, ISoftDeletable , IEntityWithName
    {
        private readonly ApplicationReadDbContext _readContext;

        public ReadRepository(ApplicationReadDbContext readContext)
        {
            _readContext = readContext;
        }

        public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _readContext.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
            return (entity != null && !entity.isDelete) ? entity : null;
        }

        public async Task<TEntity?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var entity = await _readContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.name.ToLower() == name.ToLower(), cancellationToken);
            if (entity != null && entity.isDelete)
            {
                return null;
            }

            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _readContext.Set<TEntity>()
                .Where(e => !e.isDelete)
                .ToListAsync(cancellationToken);
        }
    }
}
