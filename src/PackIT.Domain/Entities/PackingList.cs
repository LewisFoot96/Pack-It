using System.Security.Principal;
using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObject;
using PackIT.Shared.Abstractions.Domain;

namespace PackIT.Domain.Entities;

public class PackingList : AggregateRoot<PackingListId>
{
  public PackingListId Id { get; private set; }

  private PackingListName _name;

  private Localisation _localisation;

  private readonly LinkedList<PackingItem> _packingItems = new LinkedList<PackingItem>();

  internal PackingList(Guid id, PackingListName name, Localisation localisation, LinkedList<PackingItem> packingItems)
  {
    _name = name;
    _localisation = localisation;
    Id = id;
    _packingItems = packingItems;
  }

  public void AddPackingItem(PackingItem packingItem)
  {
    var alreadyExists = _packingItems.Any(i => i.Name == packingItem.Name);

    if (alreadyExists)
    {
      throw new PackingItemAlreadyExistsException(_name, packingItem.Name);
    }
  }
}
