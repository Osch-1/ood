using System;
using WeatherStationPro.Entities;
using WeatherStationPro.StatisticCounter.StatisticsDisplayStrategy;

namespace WeatherStationPro
{
    public class StatisticsDisplay : IObserver<WeatherInfo>
    {
        private readonly IStatisticsCounter<double> _temperatureStatisticsCounter;
        private readonly IStatisticsCounter<double> _humidityStatisticsCounter;
        private readonly IStatisticsCounter<double> _pressureStatisticsCounter;
        private readonly IStatisticsCounter<double> _windSpeedStatisticsCounter;
        private readonly IStatisticsCounter<double> _windDirectionStatisticsCounter;

        public StatisticsDisplay()
        {
            _temperatureStatisticsCounter = new AverageStatisticsCounter( new NumericAverageStatisticsDisplayStrategy( "temperature" ) );
            _humidityStatisticsCounter = new AverageStatisticsCounter( new NumericAverageStatisticsDisplayStrategy( "humidity" ) );
            _pressureStatisticsCounter = new AverageStatisticsCounter( new NumericAverageStatisticsDisplayStrategy( "pressure" ) );
            _windSpeedStatisticsCounter = new AverageStatisticsCounter( new NumericAverageStatisticsDisplayStrategy( "wind speed" ) );
            _windDirectionStatisticsCounter = new AverageStatisticsCounter( new CardinalPointStatisticsDisplayStrategy( "wind direction" ) );
        }

        public void Update( string source, WeatherInfo data )
        {
            _temperatureStatisticsCounter.OnNewValue( data.Temperature );
            _humidityStatisticsCounter.OnNewValue( data.Humidity );
            _pressureStatisticsCounter.OnNewValue( data.Pressure );
            _windSpeedStatisticsCounter.OnNewValue( data.WindSpeed );
            _windDirectionStatisticsCounter.OnNewValue( data.WindDirection );

            Console.WriteLine( $"Data came from: {source}" );
            _temperatureStatisticsCounter.Display();
            _humidityStatisticsCounter.Display();
            _pressureStatisticsCounter.Display();
            _windSpeedStatisticsCounter.Display();
            _windDirectionStatisticsCounter.Display();
            Console.WriteLine( $"-----------------------{Environment.NewLine}" );
        }
    }
}
