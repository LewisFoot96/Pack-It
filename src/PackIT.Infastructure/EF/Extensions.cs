using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Application.Services;
using PackIT.Domain.Repositories;
using PackIT.Infastructure.EF.Contexts;
using PackIT.Infastructure.EF.Options;
using PackIT.Infastructure.EF.Services;
using PackIT.Infastructure.Repositories;
using PackIT.Shared.Options;

namespace PackIT.Infastructure.EF;

internal static class Extensions
{
  public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddScoped<IPackingListRepository, PostgresPackingListRepository>();
    services.AddScoped<IPackingLIstReadService, PostgresPackingListReadService>();
    var options = configuration.GetOptions<PostgresOptions>("Postgres");
    services.AddDbContext<ReadDbContext>(ctx => ctx.UseNpgsql(options.ConnectionString));
    services.AddDbContext<WriteDbContext>(ctx => ctx.UseNpgsql(options.ConnectionString));
    return services;
  }
}
