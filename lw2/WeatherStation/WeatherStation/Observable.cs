using System;
using System.Collections.Generic;

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
            for ( int i = _observers.Count - 1; i >= 0; i-- )
            {
                _observers[ i ].Update( GetModifiedData() );
            }
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
