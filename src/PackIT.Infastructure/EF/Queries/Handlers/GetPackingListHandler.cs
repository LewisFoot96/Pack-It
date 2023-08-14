using Microsoft.EntityFrameworkCore;
using PackIT.Application.DTO;
using PackIT.Infastructure.EF.Contexts;
using PackIT.Infastructure.EF.Models;
using PackIT.Shared.Abstractions.Queries;

namespace PackIT.Infastructure.EF.Queries.Handlers;

internal sealed class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
{
  private readonly DbSet<PackingListReadModel> _packingLists;

  public GetPackingListHandler(ReadDbContext context)
    => _packingLists = context.PackingLists;

  public Task<PackingListDto> HandleAsync(GetPackingList query)
    => _packingLists
      .Include(pl => pl.Items)
      .Where(pl => pl.Id == query.Id)
      .Select(pl => pl.AsDto())
      .AsNoTracking()
      .SingleOrDefaultAsync()!;
  
}
