using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeManagement.Utilities
{
    public class CacheHelper
    {
        private readonly IMemoryCache _cache;

        public CacheHelper() 
        {
        
        }
        public void AddKey(String keyName, String keyValue)
        {
            using (var cacheEntry = _cache.CreateEntry(keyName))
            {
                cacheEntry.Value = keyValue;
                cacheEntry.Dispose();
            }
        }
        public String GetKeyValue(String keyName) 
        {
            return _cache != null ? _cache.Get(keyName) as String : String.Empty;
        }
    }
}
