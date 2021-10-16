using System;

namespace WeatherStationPro
{
    public interface IObservable<out T, TEvent>
        where TEvent : Enum
    {
        public void Subscribe( IObserver<T, TEvent> observer, TEvent priority );

        public void Unsubscribe( IObserver<T, TEvent> observer );

        public void Notify();
    }
}
