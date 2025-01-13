using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ToDo.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(config
            => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}