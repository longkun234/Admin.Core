using Admin.Core.Common.Cache;
using Admin.Core.Common.Output;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Admin.Core.Service.Admin.Cache
{
    public class CacheService : BaseService, ICacheService
    {
        private readonly ICache _cache;
        private readonly ILogger<CacheService> _logger;

        public CacheService(ICache cache, ILogger<CacheService> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public IResponseOutput List()
        {
            var list = new List<object>();
            var cacheKey = typeof(CacheKey);
            var fields = cacheKey.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            foreach (var field in fields)
            {
                var descriptionAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;

                list.Add(new
                {
                    field.Name,
                    Value = field.GetRawConstantValue().ToString(),
                    descriptionAttribute?.Description
                });
            }

            return ResponseOutput.Ok(list);
        }

        public async Task<IResponseOutput> ClearAsync(string cacheKey)
        {
            _logger.LogWarning($"{User.Id}.{User.Name}清除缓存[{cacheKey}]");
            await _cache.DelByPatternAsync(cacheKey);
            return ResponseOutput.Ok();
        }
    }
}