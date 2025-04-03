using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Interfaces;
using Todo.Application.Services;

namespace Todo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>(); // register UserService
            return services;
        }
    }
}
