namespace WeatherStationPro
{
    public interface IStatisticsCounter
    {
        public void OnNewValue( double value );

        public void Display();
    }
}
