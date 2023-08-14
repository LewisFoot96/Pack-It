using Microsoft.EntityFrameworkCore;
using PackIT.Application.Services;
using PackIT.Infastructure.EF.Contexts;
using PackIT.Infastructure.EF.Models;

namespace PackIT.Infastructure.EF.Services;

internal sealed class PostgresPackingListReadService : IPackingLIstReadService
{

  private readonly DbSet<PackingListReadModel> _packingList;

  public PostgresPackingListReadService(ReadDbContext context)
  {
    _packingList = context.PackingLists;
  }

  public Task<bool> ExistsByNameAsync(string name) => _packingList.AnyAsync(pl => pl.Name == name);
}
