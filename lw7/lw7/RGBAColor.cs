namespace lw7
{
    /// <summary>
    /// Represents RGBA color
    /// </summary>
    public class RGBAColor
    {
        private int _r;
        private int _g;
        private int _b;
        private double _a;

        public int R => _r;
        public int G => _g;
        public int B => _b;
        public double A => _a;

        public RGBAColor( int r, int g, int b, double a )
        {
            _r = r;
            _g = g;
            _b = b;
            _a = a;
        }

        public override bool Equals( object obj )
        {
            if ( obj is null )
            {
                return false;
            }

            if ( ReferenceEquals( this, obj ) )
            {
                return true;
            }

            if ( obj is RGBAColor other )
            {
                return other.R == R
                    && other.G == G
                    && other.B == B
                    && other.A == A;
            }

            return false;
        }
    }
}
