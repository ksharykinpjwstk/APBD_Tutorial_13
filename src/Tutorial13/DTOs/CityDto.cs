using System.ComponentModel.DataAnnotations;

namespace Tutorial13.DTOs;

public class CityDto
{
    public int Id { get; set; }
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = null!;

    [Required]
    [Range(-90,90)]
    public decimal Latitude { get; set; }

    [Required]
    [Range(-180,180)]
    public decimal Longitude { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string CountryName { get; set; }
}