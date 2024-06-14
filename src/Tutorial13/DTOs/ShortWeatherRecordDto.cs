using Microsoft.Build.Framework;
using Tutorial13.Entities;

namespace Tutorial13.DTOs;

public class ShortWeatherRecordDto : WeatherRecordDto
{
    public ShortWeatherRecordDto(WeatherRecord record)
    {
        Id = record.Id;
        City = record.City.Name;
        DateHappened = record.DateHappened;
        Temperature = record.Temperature;
        WeatherType = record.WeatherType.Name;
    }
    
    public int Id { get; set; }

    public string City { get; set; }
}