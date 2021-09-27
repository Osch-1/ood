namespace WeatherStationPro
{
    public interface IStatisticsCounter<TValue>
    {
        public void OnNewValue( TValue value );

        public void Display();
    }
}
