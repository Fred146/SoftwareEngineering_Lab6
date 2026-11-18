using WeatherStationPull.Observers.Abstractions;

namespace WeatherStationPull.Subjects.Abstractions;
public interface ISubject
{
    void RegisterObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void NotifyObservers();

    double Temperature { get; }
    double Humidity { get; }
    double Pressure { get; }
}