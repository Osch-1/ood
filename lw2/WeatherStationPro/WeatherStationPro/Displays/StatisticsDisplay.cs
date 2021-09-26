using System;
using WeatherStationPro.Dto;

namespace WeatherStationPro
{
    public class StatisticsDisplay : IObserver<WeatherInfo>
    {
        private readonly IStatisticsCounter _temperatureStatisticsCounter;
        private readonly IStatisticsCounter _humidityStatisticsCounter;
        private readonly IStatisticsCounter _pressureStatisticsCounter;

        public StatisticsDisplay()
        {
            _temperatureStatisticsCounter = new AverageStatisticsCounter( "temperature" );
            _humidityStatisticsCounter = new AverageStatisticsCounter( "humidity" );
            _pressureStatisticsCounter = new AverageStatisticsCounter( "pressure" );
        }

        public void Update( WeatherInfo data )
        {
            _temperatureStatisticsCounter.OnNewValue( data.Temperature );
            _humidityStatisticsCounter.OnNewValue( data.Humidity );
            _pressureStatisticsCounter.OnNewValue( data.Pressure );

            Console.WriteLine( $"Data came from: {data.Source}" );
            _temperatureStatisticsCounter.Display();
            _humidityStatisticsCounter.Display();
            _pressureStatisticsCounter.Display();
            Console.WriteLine( $"-----------------------{Environment.NewLine}" );
        }
    }
}
