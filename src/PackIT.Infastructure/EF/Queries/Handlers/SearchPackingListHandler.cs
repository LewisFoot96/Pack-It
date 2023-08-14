using Microsoft.EntityFrameworkCore;
using PackIT.Application.DTO;
using PackIT.Infastructure.EF.Contexts;
using PackIT.Infastructure.EF.Models;
using PackIT.Shared.Abstractions.Queries;

namespace PackIT.Infastructure.EF.Queries.Handlers;

internal sealed class SearchPackingListHandler : IQueryHandler<SearchPackingList, IEnumerable<PackingListDto>>
{
  private readonly DbSet<PackingListReadModel> _packingLists;

  public SearchPackingListHandler(ReadDbContext context)
  {
    _packingLists = context.PackingLists;
  }

  public async Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingList query)
  {
    var dbQuery = _packingLists.Include(pl => pl.Items).AsQueryable();
    if (query.SearchPhrase is not null)
    {
      dbQuery = dbQuery.Where(pl => Microsoft.EntityFrameworkCore.EF.Functions.ILike(pl.Name, $"%{query.SearchPhrase}%"));
    }
    return  await dbQuery.Select(pl => pl.AsDto()).AsNoTracking().ToListAsync();
  }
}
