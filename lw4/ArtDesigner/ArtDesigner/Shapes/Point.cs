using System;

namespace ArtDesigner.Shapes
{
    public class Point : IEquatable<Point>
    {
        private double _x;
        private double _y;

        public Point( double x, double y )
        {
            _x = x;
            _y = y;
        }

        public double X
        {
            get => _x;
            set => _x = value;
        }

        public double Y
        {
            get => _y;
            set => _y = value;
        }

        bool IEquatable<Point>.Equals( Point other )
        {
            if ( other is null )
                return false;

            if ( ReferenceEquals( other, this ) )
                return true;

            return X == other.X
                && Y == other.Y;
        }

        public override bool Equals( object obj )
        {
            if ( obj == null )
                return false;

            if ( ReferenceEquals( this, obj ) )
                return true;

            if ( obj is not Point point )
                return false;
            return Equals( point );
        }

        public override string ToString()
        {
            return $"{_x}:{_y}";
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = X.GetHashCode();
                hash = ( hash * 397 ) ^ Y.GetHashCode();

                return hash;
            }
        }
    }
}
