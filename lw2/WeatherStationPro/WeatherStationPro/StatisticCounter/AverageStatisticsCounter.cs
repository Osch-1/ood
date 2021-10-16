using WeatherStationPro.StatisticCounter.StatisticsDisplayStrategy;

namespace WeatherStationPro
{
    public class AverageStatisticsCounter : IStatisticsCounter<double>
    {
        private readonly IAverageStatisticsDisplayStrategy _statisticsDisplayStrategy;
        private double _minimal;
        private double _maximal;
        private double _total;
        private int _accCount;

        public AverageStatisticsCounter( IAverageStatisticsDisplayStrategy statisticsDisplayStrategy )
        {
            _statisticsDisplayStrategy = statisticsDisplayStrategy;
        }

        public void OnNewValue( double value )
        {
            if ( value > _maximal )
                _maximal = value;
            else if ( value < _minimal )
                _minimal = value;

            _total += value;
            _accCount++;
        }

        public void Display()
        {
            _statisticsDisplayStrategy.Display( _minimal, _maximal, GetAverage() );
        }

        private double GetAverage()
        {
            return _accCount == 0 ? 0 : _total / _accCount;
        }
    }
}
