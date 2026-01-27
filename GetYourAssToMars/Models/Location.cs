using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetYourAssToMars.Models;

public class Location
{
    [Key]    
    public int Id { get; set; }

    [Required]
    [StringLength(64)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public double Latitude { get; set; }

    [Required]
    public double Longitude { get; set; }

    [Required]
    [Range(1, 5)]
    public uint Score { get; set; }

    [Range(0, 100)]
    public uint UvIndex { get; set; }

    [Range(0.0, 10000.0)]
    public double BackgroundRadiation { get; set; }

    [Range(-100.0, 100.0)]
    public double DayTemperature { get; set; }

    [Range(-100.0, 100.0)]
    public double NightTemperature { get; set; }

    [Range(0.0, 1200.0)]
    public double AirPressure { get; set; }

    [Range(0.0, 100.0)]
    public double AirHumidity { get; set; }

    [Range(0.0, 4000.0)]
    public double AnnualPrecipitation { get; set; }

    [Required]
    [StringLength(1024)]
    public string Description { get; set; } = string.Empty;
}