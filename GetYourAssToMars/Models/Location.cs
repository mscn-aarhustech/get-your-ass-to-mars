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
    [Range(0, 100)]
    public double Score { get; set; }

    [Range(0, 100)]
    public int UvIndex { get; set; }

    [Range(0.0, 10000.0)]
    public double BackgroundRadiation { get; set; }

    [Range(-200.0, 100.0)]
    public double DayTemperature { get; set; }

    [Range(-200.0, 100.0)]
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

    public void CalculateScore()
    {
        // Earth values


        // Martian values
        const double martianUvIndex = 43.0; // UV index (0-11 on Earth) = W/m^2 / 25
        const double martianRadiation = 270.0; // millisieverts per year
        const double martianDayTemp = 20.0; // Deg C
        const double martianNightTemp = -150.0; // Deg C
        const double martianAirPress = 7.0; // mB
        const double martianHumidity = 0.03; // Absolute air humidity %
        const double martianPrecip = 0.0; // Annual precipitation mm

        // Normalized scores in range [0; 1]
        // Equation: (1 - (Math.Abs(Measured - Martian) / Range)) * Weight
        double normalizedUvIndex = 1.0 - Math.Clamp(Math.Abs(UvIndex - martianUvIndex) / martianUvIndex, 0, 1);
        double normalizedRadiation = 1.0 - Math.Clamp(Math.Abs(BackgroundRadiation - martianRadiation) / martianRadiation, 0, 1);
        double normalizedDayTemp = 1.0 - Math.Clamp(Math.Abs(DayTemperature - martianDayTemp) / 100.0, 0, 1);
        double normalizedNightTemp = 1.0 - Math.Clamp(Math.Abs(NightTemperature - martianNightTemp) / 150.0, 0, 1);
        double normalizedAirPress = 1.0 - Math.Clamp(Math.Abs(AirPressure - martianAirPress) / 1013.0, 0, 1);
        double normalizedHumidity = 1.0 - Math.Clamp(Math.Abs(AirHumidity - martianHumidity) / 100.0, 0, 1);
        double normalizedPrecipitation = 1.0 - Math.Clamp(Math.Abs(AnnualPrecipitation - martianPrecip) / 100.0, 0, 1);

        double totalScore = (
            normalizedUvIndex + 
            normalizedRadiation + 
            normalizedDayTemp + 
            normalizedNightTemp + 
            normalizedAirPress + 
            normalizedHumidity + 
            normalizedPrecipitation
        ) / 7.0;

        Score = Math.Round(totalScore * 100, 1);
    }
}