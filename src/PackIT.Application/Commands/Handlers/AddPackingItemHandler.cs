using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObject;

namespace PackIT.Application.Commands.Handlers;

public class AddPackingItemHandler
{
  private readonly IPackingListRepository _repository;

  public AddPackingItemHandler(IPackingListRepository repository)
    => _repository = repository;

  public async Task HandleAsync(AddPackingItem command)
  {
    var packingList = await _repository.GetAsync(command.PackingListId);

    if (packingList is null)
    {
      throw new PackingListNotFoundException(command.PackingListId);
    }

    var packingItem = new PackingItem(command.Name, command.Quantity);
    packingList.AddPackingItem(packingItem);

    await _repository.UpdateAsync(packingList);
  }
}
