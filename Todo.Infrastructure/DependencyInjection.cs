using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Todo.Application.Interfaces;
using Todo.Core.Options;
using Todo.Infrastructure.Data;
using Todo.Infrastructure.Repositories;

namespace Todo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>((provider, options) =>
            {
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITodoItemRepository, TodoItemRepository>();

            return services;
        }
    }
}
