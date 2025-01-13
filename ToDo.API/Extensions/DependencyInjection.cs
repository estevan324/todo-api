using ToDo.Application.Repositories;
using ToDo.Application.Services;
using ToDo.Application.Services.Interfaces;
using ToDo.Infrastructure.Repositories;

namespace ToDo.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IOwnerService, OwnerService> ();
        services.AddScoped<IToDoService, ToDoService>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
        return services;
    }
}