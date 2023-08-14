using PackIT.Domain.Const;
using PackIT.Domain.Entities;
using PackIT.Domain.Policies;
using PackIT.Domain.ValueObject;

namespace PackIT.Domain.Factories;

public sealed class PackingListFactory : IPackingListFactory
{
  private readonly IEnumerable<IPackingItemsPolicy> _policies;

  public PackingListFactory(IEnumerable<IPackingItemsPolicy> policies)
  {
    _policies = policies;
  }


  public PackingList Create(PackingListId id, PackingListName name, Localisation localisation) =>
    new PackingList(id, name, localisation);

  public PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays days, Gender gender,
    Localisation localisation, Temperature temperature)
  {
    var data = new PolicyData(days, gender, temperature, localisation);
    var applicablePolicies = _policies.Where(p => p.IsApplicable(data));

    var items = applicablePolicies.SelectMany((p => p.GenerateItems(data)));
    var packingList = Create(id, name, localisation);
    packingList.AddPackingItems(items);

    return packingList;
  }
}
