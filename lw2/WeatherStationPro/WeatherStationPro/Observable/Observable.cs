using System;
using System.Collections.Generic;
using System.Linq;
using WeatherStationPro.Entities;

namespace WeatherStationPro.Observable
{
    public class Observable<TValType, TEvent> : IObservable<TValType, TEvent>
        where TEvent : Enum
    {
        private readonly TEvent _leastPriority = default;

        private readonly IComparer<int> _comparer = new DescendingComparer<int>();
        private readonly Dictionary<TEvent, SortedDictionary<int, HashSet<IObserver<TValType>>>> _observers = new();
        private readonly string _name;

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public Observable( string name )
        {
            _name = name;
        }

        public void Subscribe( IObserver<TValType> observer, TEvent priority )
        {
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
                    o.Update( Name, modifiedData ) ) );
        }

        public void Unsubscribe( IObserver<TValType> observer )
        {
            var setToRemoveFrom = _observers.FirstOrDefault( obs => obs.Value.Contains( observer ) ).Value;
            setToRemoveFrom?.Remove( observer );
        }

        protected virtual TValType GetModifiedData()
        {
            return default;
        }

        private void SubscribeByPriority( IObserver<TValType> observer, TEvent priority )
        {
            if ( !_observers.ContainsKey( priority ) )
            {
                _observers.Add( priority, new HashSet<IObserver<TValType>>() );
            }

            _observers[ priority ].Add( observer );
        }
    }
}
