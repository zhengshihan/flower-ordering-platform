using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWebsite.Common
{
    public class MemoryHelper
    {
        private static IMemoryCache _memoryCache = null;
        static MemoryHelper()
        {
            if (_memoryCache == null)
            {
                _memoryCache = new MemoryCache(new MemoryCacheOptions());
            }
        }
        public static void SetMemory(string key, object value, int expireMins)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(expireMins));
        }
        public static object GetMemory(string key)
        {
            return _memoryCache.Get(key);
        }
    }
}
