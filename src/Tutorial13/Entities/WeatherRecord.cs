namespace Tutorial13.Entities;

public partial class WeatherRecord
{
    public int Id { get; set; }

    public int CityId { get; set; }

    public int WeatherTypeId { get; set; }

    public int Temperature { get; set; }

    public DateTime DateHappened { get; set; }

    public string? Description { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual WeatherType WeatherType { get; set; } = null!;
}
