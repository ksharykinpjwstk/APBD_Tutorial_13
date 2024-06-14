using Tutorial13.Entities;

namespace Tutorial13.DTOs;

public class LongWeatherRecordDto : WeatherRecordDto
{
    public LongWeatherRecordDto(WeatherRecord record)
    {
        WeatherType = record.WeatherType.Name;
        CityInformation = new CityDto
        {
            Name = record.City.Name,
            CountryName = record.City.Country.Name,
            Latitude = record.City.Latitude,
            Longitude = record.City.Longitude
        };
        Description = record.Description;
        Temperature = record.Temperature;
        DateHappened = record.DateHappened;
    }

    public CityDto CityInformation { get; set; } = null!;
    
    public string? Description { get; set; }
}