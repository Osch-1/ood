namespace WeatherStationPro
{
    public interface IObserver<in T>
    {
        public void Update( string source, T data );
    }
}
