namespace lw7
{
    /// <summary>
    /// Represents RGBA color
    /// </summary>
    public class RGBAColor : IRGBAColor
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
    }
}
