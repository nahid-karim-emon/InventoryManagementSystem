using IMS.Core.Common;
using IMS.Core.CoreInterface;
using IMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Core
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity>
    where TEntity : class, ISoftDeletable
    {
        private readonly ApplicationWriteDbContext _writeContext;
        public WriteRepository(ApplicationWriteDbContext writeContext)
        {
            _writeContext = writeContext;
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _writeContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        }

        public void Update(TEntity entity)
        {
            _writeContext.Set<TEntity>().Attach(entity);
            _writeContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            entity.isDelete = true;
            _writeContext.Set<TEntity>().Update(entity);
        }
    }
}
