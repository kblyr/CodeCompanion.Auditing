using Microsoft.Extensions.DependencyInjection;

namespace CodeCompanion.Auditing
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCurrentTimestampProvider(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            services.Add(new ServiceDescriptor(typeof(ICurrentTimestampProvider), typeof(CurrentTimestampProvider), lifetime));
            return services;
        }

        public static IServiceCollection AddCurrentTimestampProvider(this IServiceCollection services, Func<IServiceProvider, DateTimeOffset?> factory, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            services.Add(new ServiceDescriptor(typeof(ICurrentTimestampProvider), serviceProvider => new FixedCurrentTimestampProvider(factory(serviceProvider)), lifetime));
            return services;
        }

        public static IServiceCollection AddCurrentUserIdProvider(this IServiceCollection services, int? currentUserId, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            services.Add(new ServiceDescriptor(typeof(ICurrentUserIdProvider), (_) => new CurrentUserIdProvider(currentUserId), lifetime));
            return services;
        }

        public static IServiceCollection AddCurrentUserIdProvider(this IServiceCollection services, Func<IServiceProvider, int?> factory, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            services.Add(new ServiceDescriptor(typeof(ICurrentUserIdProvider), serviceProvider => new CurrentUserIdProvider(factory(serviceProvider)), lifetime));
            return services;
        }

        public static IServiceCollection AddCurrentFootprintProvider(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            services.Add(new ServiceDescriptor(typeof(ICurrentFootprintProvider), typeof(CurrentFootprintProvider), lifetime));
            return services;
        }
    }
}