using WeatherStationPull.Observers.Abstractions;
using WeatherStationPull.Subjects.Abstractions;

namespace WeatherStationPull.Subjects;

public class WeatherData : ISubject
{
    private readonly List<IObserver> _observers;
    private double _temperature;
    private double _humidity;
    private double _pressure;

    public WeatherData()
    {
        _observers = new List<IObserver>();
    }

    // Pull: observers vragen de data zelf op via deze properties
    public double Temperature => _temperature;
    public double Humidity => _humidity;
    public double Pressure => _pressure;

    public void MeasurementsChanged()
    {
        NotifyObservers();
    }

    public void SetMeasurements(double temperature, double humidity, double pressure)
    {
        _temperature = temperature;
        _humidity = humidity;
        _pressure = pressure;
        MeasurementsChanged();
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(); // geen data meer meesturen
        }
    }

    public void RegisterObserver(IObserver o)
    {
        _observers.Add(o);
    }

    public void RemoveObserver(IObserver o)
    {
        _observers.Remove(o);
    }
}