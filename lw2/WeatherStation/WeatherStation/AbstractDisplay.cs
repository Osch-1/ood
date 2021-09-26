using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    public class AbstractDisplay : IObserver<WeatherInfo>
    {
        private readonly Dictionary<string, IStatisticsCounter> _statisticsCounters;

        private readonly string _temperatureStatisticsCounterName = "temperature";
        private readonly string _humidityStatisticsCounterName = "humidity";
        private readonly string _pressureStatisticsCounterName = "pressure";

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
