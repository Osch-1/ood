using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherStationPro.Observable
{
    public class Observable<T> : IObservable<T>
    {
        private const int _leastPriority = 0;

        private readonly SortedDictionary<int, HashSet<IObserver<T>>> _observers = new( new DescendingComparer<int>() );

        public void Subscribe( IObserver<T> observer )
        {
            if ( observer is null )
                throw new ArgumentNullException( nameof( observer ) );

            SubscribeByPriority( observer, _leastPriority );
        }

        public void Subscribe( IObserver<T> observer, int priority )
        {
            if ( priority < 0 )
                throw new ArgumentException( "Parameter can't be negative.", nameof( priority ) );

            if ( observer is null )
                throw new ArgumentNullException( nameof( observer ) );

            SubscribeByPriority( observer, priority );
        }

        public void Notify()
        {
            var modifiedData = GetModifiedData();

            var observers = _observers.ToList();
            observers.ForEach( obs =>
                obs.Value.ToList().ForEach( o =>
                    o.Update( modifiedData ) ) );
        }

        public void Unsubscribe( IObserver<T> observer )
        {
            var setToRemoveFrom = _observers.FirstOrDefault( obs => obs.Value.Contains( observer ) ).Value;
            setToRemoveFrom?.Remove( observer );
        }

        protected virtual T GetModifiedData()
        {
            return default;
        }

        private void SubscribeByPriority( IObserver<T> observer, int priority )
        {
            if ( !_observers.ContainsKey( priority ) )
            {
                _observers.Add( priority, new HashSet<IObserver<T>>() );
            }

            _observers[ priority ].Add( observer );
        }
    }
}
