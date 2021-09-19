namespace WeatherStation
{
    public class WeatherStation : Observable<WeatherInfo>
    {
        private double _temperature = 0;
        private double _humidity = 0;
        private double _pressure = 0;

        public void SetMeasurments( double temperature, double humidity, double pressure )
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;

            Notify();
        }

        protected override WeatherInfo GetModifiedData()
        {
            return new WeatherInfo
            {
                Temperature = _temperature,
                Humidity = _humidity,
                Pressure = _pressure
            };
        }
    }
}
