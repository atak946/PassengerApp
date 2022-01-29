using Gozen.Domain.Abstract;
using Gozen.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gozen.Infrastructure.Repository
{
    public class RedisRepository : IRedisRepository
    {
        private bool _disposed = false;
        private readonly RedisContext _context;

        public RedisRepository(RedisContext context)
        {
            _context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    GC.SuppressFinalize(_context);
                }
            }

            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRedisService<T> GetRepository<T>() where T : class
        {
            return new RedisService<T>(_context);
        }
    } 
}
