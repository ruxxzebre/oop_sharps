using System.IO;
using System.Text.Json;
using System.Linq;
using System;

namespace sharpz
{
  public enum WeatherType { Undefined, Rain, ShortRain, Thunder, Snow, Fog, Gloom, Sun };

  public class Task7
  {
    public static void run() 
    {
      Console.Write("Path: ");
      var path = Path.GetFullPath($"Task 7/{Console.ReadLine()}");
      WeatherDays w = new WeatherDays();
      try {
        w.LoadFromFile(path);
        Task7 t = new Task7(w);
        t.CountFoggyDays();
        t.CountNoPrecipitationDays();
        t.MaximalAtmosphericPressure();
        t.MinimalAtmosphericPressure();
      } catch(Exception) {
        Console.WriteLine($"Invalid path {path}");
      }
    }

    private WeatherDays weatherDays;

    private static string FOGGYDAYS_COUNT = "Foggy days count: ";
    private static string NOPRECIPITATION_COUNT = "No precipitation days count: ";
    private static string MINIMAL_PRESSURE = "Minimal atmospheric pressure: ";
    private static string MAXIMAL_PRESSURE = "Maximal atmospheric pressure: ";

    public Task7(WeatherDays weatherDays)
    {
      this.weatherDays = weatherDays;
    }

    public void CountFoggyDays()
    {
      int foggyDaysCount = weatherDays.WeatherParametersDays.Count((day) => day.WeatherType == WeatherType.Fog);

      Console.WriteLine(FOGGYDAYS_COUNT + foggyDaysCount);
    }

    public void CountNoPrecipitationDays()
    {
      int noPrecipitationDays = weatherDays.WeatherParametersDays.Count((day) => day.WeatherType != WeatherType.Rain && day.WeatherType != WeatherType.ShortRain && day.WeatherType != WeatherType.Snow);

      Console.WriteLine(NOPRECIPITATION_COUNT + noPrecipitationDays);
    }

    public void MinimalAtmosphericPressure()
    {
      float minPressure = weatherDays.WeatherParametersDays.OrderBy((day) => day.AverageAtmosphericPressure).First().AverageAtmosphericPressure;

      Console.WriteLine(MINIMAL_PRESSURE + minPressure);
    }

    public void MaximalAtmosphericPressure()
    {
      float maxPressure = weatherDays.WeatherParametersDays.OrderByDescending((day) => day.AverageAtmosphericPressure).First().AverageAtmosphericPressure;

      Console.WriteLine(MAXIMAL_PRESSURE + maxPressure);
    }
  }

  public class WeatherDays
  {
    public WeatherParametersDay[] WeatherParametersDays { get; private set; }

    public void LoadFromFile(string jsonDataPath)
    {
      string data = File.ReadAllText(jsonDataPath);

      WeatherParametersDays = JsonSerializer.Deserialize<WeatherParametersDay[]>(data);
    }
  }

  public struct WeatherParametersDay
  {
    public float AverageDayTemperature { get; set; }
    public float AverageNightTemperature { get; set; }
    public float AverageAtmosphericPressure { get; set; }
    public float PrecipitationMmDay { get; set; }
    public WeatherType WeatherType { get; set; }
  }
}
