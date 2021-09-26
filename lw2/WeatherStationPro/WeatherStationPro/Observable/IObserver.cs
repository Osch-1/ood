namespace WeatherStationPro
{
    public interface IObserver<in T>
    {
        public void Update( T data );
    }
}
