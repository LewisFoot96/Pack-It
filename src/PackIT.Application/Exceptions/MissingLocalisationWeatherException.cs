using PackIT.Domain.ValueObject;
using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Application.Exceptions;

public class MissingLocalisationWeatherException : PackItException
{
  public MissingLocalisationWeatherException(Localisation localisation) : base($"Could not fetch weather data for localisation '{localisation.Country}/{localisation.City}'")
  {
  }
}
