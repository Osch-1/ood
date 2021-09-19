namespace WeatherStation
{
    public interface IStatisticsCounter
    {
        public void OnNewValue( double value );

        public void Display();
    }
}
