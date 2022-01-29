using Gozen.Application.Abstract;
using Gozen.Application.Services;
using Gozen.Domain.Abstract;
using Gozen.Domain.Models;
using Gozen.Domain.Settings;
using Gozen.Infrastructure.Context;
using Gozen.Infrastructure.Repository;
using Gozen.Infrastructure.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Gozen.Infrastructure.IoC.DependencyContainer
{
    public static class ContainerService
    {
        public static IServiceCollection RegisterContainer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPassengerService, PassengerService>();
            services.AddScoped<IRedisRepository, RedisRepository>();

            services.Configure<RedisSettings>(configuration.GetSection("RedisSettings"));

            services.AddSingleton(sp =>
            {
                var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;

                var redis = new RedisContext(redisSettings.Host, redisSettings.Port);

                redis.Connect();

                return redis;
            });

            return services;
        }

        public static IApplicationBuilder UseApplicationDependency(this IApplicationBuilder app)
        {
            using (var services = app.ApplicationServices.CreateScope())
            {
                var redisService = services.ServiceProvider.GetRequiredService<IRedisRepository>();

                new RedisSeed(redisService.GetRepository<List<Passenger>>()).Seed();
            }

            return app;
        }
    }
}
