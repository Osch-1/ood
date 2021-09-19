using System;
using System.Collections.Generic;

namespace WeatherStation
{
    public class StatisticsDisplay : IObserver<WeatherInfo>
    {
        private readonly Dictionary<string, IStatisticsCounter> _statisticsCounters;

        private readonly string _temperatureStatisticsCounterName = "temperature";
        private readonly string _humidityStatisticsCounterName = "humidity";
        private readonly string _pressureStatisticsCounterName = "pressure";

        public StatisticsDisplay()
        {
            _statisticsCounters = new Dictionary<string, IStatisticsCounter>
            {
                { _temperatureStatisticsCounterName, new AvarageStatisticsCounter( _temperatureStatisticsCounterName ) },
                { _humidityStatisticsCounterName, new AvarageStatisticsCounter( _humidityStatisticsCounterName ) },
                { _pressureStatisticsCounterName, new AvarageStatisticsCounter( _pressureStatisticsCounterName ) }
            };
        }

        public void Update( WeatherInfo data )
        {
            _statisticsCounters[ _temperatureStatisticsCounterName ].OnNewValue( data.Temperature );
            _statisticsCounters[ _humidityStatisticsCounterName ].OnNewValue( data.Humidity );
            _statisticsCounters[ _pressureStatisticsCounterName ].OnNewValue( data.Pressure );

            foreach ( var statCounter in _statisticsCounters.Values )
            {
                statCounter.Display();
            }

            Console.WriteLine( $"-----------------------{Environment.NewLine}" );
        }
    }
}
