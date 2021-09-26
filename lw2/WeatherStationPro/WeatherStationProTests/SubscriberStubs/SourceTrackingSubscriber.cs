using WeatherStationPro;
using System.Collections.Generic;
using WeatherStationPro.Dto;

namespace WeatherStationProTests.SubscriberStubs
{
    public class SourceTrackingSubscriber : IObserver<WeatherInfo>
    {
        public List<string> UpdatedBy { get; set; } = new();

        public void Update( WeatherInfo data )
        {
            UpdatedBy.Add( data.Source );
        }
    }
}
