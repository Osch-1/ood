using System;

namespace ArtDesigner.Primitives
{
    public struct Point : IEquatable<Point>
    {
        private double _x;
        private double _y;

        public double X
        {
            get => _x;
            set => _x = Math.Round( value, 2 );
        }

        public double Y
        {
            get => _y;
            set => _y = Math.Round( value, 2 );
        }

        public Point( double x, double y )
        {
            _x = Math.Round( x, 2 );
            _y = Math.Round( y, 2 );
        }

        public override string ToString()
        {
            return $"{{{_x},{_y}}}";
        }

        public override bool Equals( object obj )
        {
            if ( obj is null || !GetType().Equals( obj.GetType() ) )
            {
                return false;
            }

            return Equals( ( Point )obj );
        }

        public bool Equals( Point other )
        {
            return _x == other._x
                && _y == other._y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine( _x, _y );
        }
    }
}