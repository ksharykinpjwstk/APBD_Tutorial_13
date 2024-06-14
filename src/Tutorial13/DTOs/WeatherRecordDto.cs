using System.ComponentModel.DataAnnotations;

namespace Tutorial13.DTOs;

public abstract class WeatherRecordDto
{
    [Required]
    [MaxLength(200)]
    public string WeatherType { get; set; } = null!;
    [Required]
    [Range(-120, 80)]
    public int Temperature { get; set; }
    [Required]
    public DateTime DateHappened { get; set; }
}