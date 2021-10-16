using WeatherStationPro.Entities;
using WeatherStationPro.Observable;

namespace WeatherStationPro.WeatherStations
{
    public class InsideWeatherStation : Observable<WeatherInfo>
    {
        private double _temperature = 0;
        private double _humidity = 0;
        private double _pressure = 0;
        private double _windSpeed = 0;
        private double _windDirection = 0;

        public InsideWeatherStation()
            : base( "Inside weather station" )
        {
        }

        public void SetMeasurments( double temperature, double humidity, double pressure, double windSpeed, double windDirection )
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
            _windSpeed = windSpeed;
            _windDirection = windDirection % 360;

            Notify();
        }

        protected override WeatherInfo GetModifiedData()
        {
            return new WeatherInfo
            {
                Temperature = _temperature,
                Humidity = _humidity,
                Pressure = _pressure,
                WindSpeed = _windSpeed,
                WindDirection = _windDirection
            };
        }
    }
}
