using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gozen.Domain.Abstract
{
    public interface IRedisRepository : IDisposable
    {
        IRedisService<T> GetRepository<T>() where T : class;
    }
}
