using PackIT.Application.DTO;
using PackIT.Shared.Abstractions.Queries;

namespace PackIT.Infastructure.EF.Queries;

public class GetPackingList : IQuery<PackingListDto>
{
  public Guid Id { get; set; }
}
