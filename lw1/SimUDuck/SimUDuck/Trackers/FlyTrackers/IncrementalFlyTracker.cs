using System;

namespace SimUDuck.Trackers.FlyTrackers
{
    //можно сделать декоратор, можно внутри утки определять что делать - без фабрики не оч
    public class IncrementalFlyTracker : IFlyTrackBehavior
    {
        private int _flightsCount;
        public int FlightsCount => _flightsCount;

        public void OnFly()
        {
            _flightsCount++;
            Console.WriteLine( $"Flight number: {_flightsCount}" );
        }
    }
}
