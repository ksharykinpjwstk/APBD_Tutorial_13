namespace Tutorial13.Entities;

public class City
{
    public int Id { get; set; }

    public int CountryId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<WeatherRecord> WeatherRecords { get; set; } = new List<WeatherRecord>();
}
