using PackIT.Domain.Const;
using PackIT.Domain.ValueObject;

namespace PackIT.Domain.Policies;

public record PolicyData(TravelDays Days, Const.Gender Gender, ValueObject.Temperature Temperature, Localisation Localisation)
{
  
}
