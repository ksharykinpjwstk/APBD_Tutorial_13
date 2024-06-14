namespace Tutorial13.Entities;

public class WeatherType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<WeatherRecord> WeatherRecords { get; set; } = new List<WeatherRecord>();
}
