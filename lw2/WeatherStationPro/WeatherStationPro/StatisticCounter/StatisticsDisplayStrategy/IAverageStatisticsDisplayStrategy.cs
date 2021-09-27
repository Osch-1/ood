namespace WeatherStationPro.StatisticCounter.StatisticsDisplayStrategy
{
    public interface IAverageStatisticsDisplayStrategy //<TArgs> to avoid dependence on data type
    {
        public void Display( double min, double max, double average );
    }
}
