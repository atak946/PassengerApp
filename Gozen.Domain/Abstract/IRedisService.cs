using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gozen.Domain.Abstract
{
    public interface IRedisService<T>
    {
        public T Get(string key);
        public Task<T> GetAsync(string key);
        public void Set(string key,T value);
        public Task SetAsync(string key,T value);
        public void Remove(string key);
        public Task RemoveAsync(string key);
    }
}
