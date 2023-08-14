using PackIT.Application.DTO.External;
using PackIT.Domain.ValueObject;

namespace PackIT.Application.Services;

public interface IWeatherService
{
  Task<WeatherDTO> GetWeatherAsync(Localisation localisation);
}
