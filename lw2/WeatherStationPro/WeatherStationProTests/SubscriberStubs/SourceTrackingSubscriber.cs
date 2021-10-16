using WeatherStationPro;
using System.Collections.Generic;
using WeatherStationPro.Entities;

namespace WeatherStationProTests.SubscriberStubs
{
    public class SourceTrackingSubscriber : IObserver<WeatherInfo>, IObserver<OutsideWeatherInfo>
    {
        public List<string> UpdatedBy { get; set; } = new();

        public void Update( string source, WeatherInfo data )
        {
            UpdatedBy.Add( source );
        }

        public void Update( string source, OutsideWeatherInfo data )
        {
            UpdatedBy.Add( source );
        }
    }
}
