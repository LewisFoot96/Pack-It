using PackIT.Domain.Entities;
using PackIT.Domain.ValueObject;
using PackIT.Shared.Abstractions.Domain;

namespace PackIT.Domain.Events;

public record PackingItemPacked (PackingList packingList, PackingItem packingItem) : IDomainEvent //Domain events are used to say whether the object has successfully been updated, as the implementation is encapsulated.
{
  
}
