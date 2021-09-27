using System;

namespace WeatherStationPro.StatisticCounter.StatisticsDisplayStrategy
{
    public class NumericAverageStatisticsDisplayStrategy : IAverageStatisticsDisplayStrategy
    {
        private readonly string _name;

        public NumericAverageStatisticsDisplayStrategy( string name )
        {
            _name = name;
        }

        public void Display( double min, double max, double average )
        {
            Console.WriteLine( $"Maximal {_name}: {min:0.##}" );
            Console.WriteLine( $"Minimal {_name}: {max:0.##}" );
            Console.WriteLine( $"Average {_name}: {average:0.##}" );
        }
    }
}
