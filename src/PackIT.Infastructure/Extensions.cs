using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Application.Services;
using PackIT.Domain.Factories;
using PackIT.Domain.Policies;
using PackIT.Infastructure.EF;
using PackIT.Infastructure.EF.Options;
using PackIT.Infastructure.Services;
using PackIT.Shared.Commands;
using PackIT.Shared.Options;
using PackIT.Shared.Queries;

namespace PackIT.Infastructure;

public static class Extensions
{
  public static IServiceCollection AddInfastructure(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddPostgres(configuration);
    services.AddQueries();
    services.AddSingleton<IWeatherService, DumpWeatherService>();
    return services;
  }
}
