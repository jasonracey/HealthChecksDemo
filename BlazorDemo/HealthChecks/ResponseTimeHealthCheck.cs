using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDemo.HealthChecks
{
    public class ResponseTimeHealthCheck : IHealthCheck
    {
        private static Random random = new Random();

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            int responseTimeInMS = random.Next(1, 300);

            return responseTimeInMS switch
            {
                < 100 => Task.FromResult(HealthCheckResult.Healthy($"Healthy ({responseTimeInMS} ms)")),
                < 200 => Task.FromResult(HealthCheckResult.Degraded($"Degraded ({responseTimeInMS} ms)")),
                _ => Task.FromResult(HealthCheckResult.Unhealthy($"Unhealthy ({responseTimeInMS} ms)")),
            };
        }
    }
}
