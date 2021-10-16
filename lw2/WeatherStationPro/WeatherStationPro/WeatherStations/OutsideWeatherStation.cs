using WeatherStationPro.Entities;
using WeatherStationPro.Observable;

namespace WeatherStationPro.WeatherStations
{
    public class OutsideWeatherStation : Observable<OutsideWeatherInfo>
    {
        private double _temperature = 0;
        private double _humidity = 0;
        private double _pressure = 0;

        public OutsideWeatherStation()
            : base( "Outside weather station" )
        {

        }

        public void SetMeasurments( double temperature, double humidity, double pressure )
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;

            Notify();
        }

        protected override OutsideWeatherInfo GetModifiedData()
        {
            return new OutsideWeatherInfo
            {
                Temperature = _temperature,
                Humidity = _humidity,
                Pressure = _pressure
            };
        }
    }
}
