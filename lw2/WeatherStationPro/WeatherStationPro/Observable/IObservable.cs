namespace WeatherStationPro
{
    public interface IObservable<out T>
    {
        public void Subscribe( IObserver<T> observer );

        public void Subscribe( IObserver<T> observer, int priority );

        public void Unsubscribe( IObserver<T> observer );

        public void Notify();
    }
}
