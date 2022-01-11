using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;

namespace WebAppRedisCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly IDistributedCache _distributedCache;
        public HealthCheckController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public string GetStatus()
        {
            var key = "healthCheckStatus";
            //var lastStatus = _distributedCache.Get(key);
            var lastStatus = _distributedCache.GetString(key);
            var actualStatus = $"{DateTime.UtcNow:o}";
            _distributedCache.SetString(key, actualStatus);

            var result = $"Atual Status: {actualStatus} | Antigo Status: {lastStatus}";

            return result;
        }
    }
}
