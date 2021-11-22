namespace ModernGraphicsLib
{
    public class Point : IEquatable<Point>
    {
        private int _x;
        private int _y;

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        public Point( int x, int y )
        {
            X = x;
            Y = y;
        }
        public override bool Equals( object obj )
        {
            return ( ( IEquatable<Point> )this ).Equals( obj as Point );
        }

        bool IEquatable<Point>.Equals( Point other )
        {
            if (other is null)
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