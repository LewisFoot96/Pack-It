using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions;

public class InvalidTemperatureException : PackItException
{
  public double Temperature { get; }

  public InvalidTemperatureException(double temperature) : base($"Invalid temperature: '{temperature}") => Temperature = temperature;
}
