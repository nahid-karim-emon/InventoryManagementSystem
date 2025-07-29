using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Core
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
    public interface IReadDbConnectionFactory : IDbConnectionFactory { }

    public interface IWriteDbConnectionFactory : IDbConnectionFactory { }
}
