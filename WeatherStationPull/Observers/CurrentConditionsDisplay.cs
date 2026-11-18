using WeatherStationPull.Observers.Abstractions;
using WeatherStationPull.Subjects.Abstractions;

namespace WeatherStationPull.Observers;

public class CurrentConditionsDisplay : IObserver, IDisplayElement
{
    private double _temperature;
    private double _humidity;
    private readonly ISubject _weatherData;

    public CurrentConditionsDisplay(ISubject weatherData)
    {
        _weatherData = weatherData;
        _weatherData.RegisterObserver(this);
    }

    public void Display()
    {
        Console.WriteLine("Current conditions: " + _temperature + "F degrees and " + _humidity + "% humidity");
    }

    public void Update()
    {
        _temperature = _weatherData.Temperature;
        _humidity = _weatherData.Humidity;
        Display();
    }
}
