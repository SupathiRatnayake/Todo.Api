using Todo.Application;
using Todo.Core;
using Todo.Infrastructure;

namespace Todo.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI()
                .AddCoreDI(configuration);
            return services;
        }
    }
}
