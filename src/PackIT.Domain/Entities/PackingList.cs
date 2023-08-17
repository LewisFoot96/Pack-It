using System.Security.Principal;
using PackIT.Domain.Events;
using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObject;
using PackIT.Shared.Abstractions.Domain;

namespace PackIT.Domain.Entities;

public class PackingList : AggregateRoot<PackingListId>
{
  
  public new PackingListId Id { get; private set; } = null!;

  private PackingListName _name = null!;

  private Localisation _localisation = null!;

  private readonly LinkedList<PackingItem> _packingItems = new();

  private PackingList(Guid id, PackingListName name, Localisation localisation, LinkedList<PackingItem> packingItems) : this(id,name,localisation)
  {
    AddPackingItems(packingItems);
  }

  public PackingList()
  {
    
  }
  
  internal PackingList(Guid id, PackingListName name, Localisation localisation)
  {
    _name = name;
    _localisation = localisation;
    Id = id;
  }

  public void AddPackingItem(PackingItem packingItem)
  {
    var alreadyExists = _packingItems.Any(i => i.Name == packingItem.Name);

    if (alreadyExists)
    {
      throw new PackingItemAlreadyExistsException(_name, packingItem.Name);
    }

    _packingItems.AddLast(packingItem);
    AddEvent(new PackingItemAdded(this, packingItem ));
  }
  
  public void AddPackingItems(IEnumerable<PackingItem> packingItems)
  {
    foreach (var packingItem in packingItems)
    {
      AddPackingItem(packingItem);
    }
  }

  public void PackItem(string itemName)
  {
    var item = GetItem(itemName);
    var packedItem = item with { IsPacked = true }; //With allows me to change property value from a record. 

    _packingItems.Find(item)!.Value = packedItem;
    AddEvent(new PackingItemPacked(this, item));
  }

  public void RemoveItem(string itemName)
  {
    var item = GetItem(itemName);
    _packingItems.Remove(item);
    AddEvent(new PackingItemRemoved(this, item));
  }

  private PackingItem GetItem(string itemName)
  {
    var item = _packingItems.SingleOrDefault(i => i.Name == itemName);
    if (item is null)
    {
      throw new PackingItemNotFoundException(itemName);
    }

    return item;
  }
}
