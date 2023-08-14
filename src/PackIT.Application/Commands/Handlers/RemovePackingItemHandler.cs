using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;

namespace PackIT.Application.Commands.Handlers;

public sealed class RemovePackingItemHandler
{
  private readonly IPackingListRepository _repository;

  public RemovePackingItemHandler(IPackingListRepository repository)
    => _repository = repository;

  public async Task HandleAsync(RemovePackingItem command)
  {
    var packingList = await _repository.GetAsync(command.PackingListId);

    if (packingList is null)
    {
      throw new PackingListNotFoundException(command.PackingListId);
    }

    packingList.RemoveItem(command.Name);

    await _repository.UpdateAsync(packingList);
  }
}
