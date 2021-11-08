using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CodeCompanion.Auditing
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCurrentUserIdProvider(this IServiceCollection services, string claimType, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            services.Add(new ServiceDescriptor(typeof(ICurrentUserIdProvider), serviceProvider => new CurrentUserIdProvider(serviceProvider.GetRequiredService<IHttpContextAccessor>(), claimType), lifetime));
            return services;
        }
    }
}