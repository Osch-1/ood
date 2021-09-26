using System;
using System.Collections.Generic;

namespace WeatherStationPro
{
    public class DescendingComparer<T> : IComparer<T>
        where T : IComparable<T>
    {
        public int Compare( T x, T y )
        {
            return -x.CompareTo( y );
        }
    }
}
