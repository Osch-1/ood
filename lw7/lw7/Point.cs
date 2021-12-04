namespace lw7
{
    public class Point : IEquatable<Point>
    {
        private double _x;
        private double _y;

        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }

        public Point( double x, double y )
        {
            X = x;
            Y = y;
        }

        public override bool Equals( object obj )
        {
            if ( obj is null )
            {
                return false;
            }

            return ( ( IEquatable<Point> )this ).Equals( obj as Point );
        }

        bool IEquatable<Point>.Equals( Point other )
        {
            if ( other is null )
            {
                return false;
            }

            return X == other.X
                && Y == other.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine( _x, _y );
        }
    }
}