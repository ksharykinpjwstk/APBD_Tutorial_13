using System.ComponentModel.DataAnnotations;
using Tutorial13.Entities;

namespace Tutorial13.DTOs;

public class AddWeatherRecordDto : WeatherRecordDto
{
    [Required]
    public int CityId { get; set; }
    [MaxLength(2000)]
    public string? Description { get; set; }

    public WeatherRecord Map()
    {
        return new WeatherRecord
        {
            CityId = CityId,
            Description = Description,
            DateHappened = DateHappened,
            Temperature = Temperature,
        };
    }
}