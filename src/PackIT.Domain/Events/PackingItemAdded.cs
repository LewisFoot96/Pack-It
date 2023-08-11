using PackIT.Domain.Entities;
using PackIT.Domain.ValueObject;
using PackIT.Shared.Abstractions.Domain;

namespace PackIT.Domain.Events;

public record PackingItemAdded (PackingList packingList, PackingItem packingItem) : IDomainEvent
{

}
