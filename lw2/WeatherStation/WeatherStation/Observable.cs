using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherStation
{
    public class Observable<T> : IObservable<T>
    {
        private readonly List<IObserver<T>> _observers = new();

        public void Subscribe( IObserver<T> observer )
        {
            if ( observer is null )
                throw new ArgumentNullException( nameof( observer ) );

            if ( !_observers.Contains( observer ) )
            {
                _observers.Add( observer );
            }
        }

        public void Notify()
        {
            var observers = _observers.ToList();
            observers.ForEach( obs => obs.Update( GetModifiedData() ) );
        }

        public void Unsubscribe( IObserver<T> observer )
        {
            _observers.Remove( observer );
        }

        protected virtual T GetModifiedData()
        {
            return default;
        }
    }
}
