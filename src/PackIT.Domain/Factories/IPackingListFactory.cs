using PackIT.Domain.Const;
using PackIT.Domain.Entities;
using PackIT.Domain.ValueObject;

namespace PackIT.Domain.Factories;

public interface IPackingListFactory
{
  PackingList Create(PackingListId id, PackingListName name, Localisation localisation);
  
  PackingList CreateWithDefaultItems(PackingListId id, PackingListName name,TravelDays days, Gender gender, Localisation localisation, Temperature temperature);
}
