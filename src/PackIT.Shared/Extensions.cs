using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Abstractions.Commands;
using PackIT.Shared.Commands;
using PackIT.Shared.Services;

namespace PackIT.Shared;

public static class Extensions
{
  public static IServiceCollection AddShared(this IServiceCollection services)
  {
    services.AddHostedService<AppInitializer>();

    return services;
  }
}
