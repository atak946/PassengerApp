using Gozen.Domain.Abstract;
using Gozen.Infrastructure.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gozen.Infrastructure.Repository
{
    internal class RedisService<T> : IRedisService<T> where T : class
    {
        private readonly RedisContext context;

        public RedisService(RedisContext _context)
        {
            this.context = _context;
        }

        public T Get(string key)
        {
            var data = context.GetDb().StringGet(key);

            if (data.IsNullOrEmpty)
            {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(data);
            }
        }

        public async Task<T> GetAsync(string key)
        {
            var data = await context.GetDb().StringGetAsync(key);

            if(data.IsNullOrEmpty)
            {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(data);
            }
        }

        public void Remove(string key)
        {
            context.GetDb().KeyDelete(key);
        }

        public async Task RemoveAsync(string key)
        {
            await context.GetDb().KeyDeleteAsync(key);
        }

        public void Set(string key, T value)
        {
            context.GetDb().StringSet(key,JsonConvert.SerializeObject(value));
        }

        public async Task SetAsync(string key, T value)
        {
            await context.GetDb().StringSetAsync(key, JsonConvert.SerializeObject(value));
        }
    }
}