using System;

namespace WeatherStation
{
    public interface IObservable<out T>
    {
        public void Subscribe( IObserver<T> observer );

        public void Unsubscribe( IObserver<T> observer );

        public void Notify();
    }
}
