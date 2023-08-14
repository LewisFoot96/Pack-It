using PackIT.Application.DTO;
using PackIT.Shared.Abstractions.Queries;

namespace PackIT.Infastructure.EF.Queries;

public class SearchPackingList : IQuery<IEnumerable<PackingListDto>>
{
  public string SearchPhrase { get; set; } = null!;
}
