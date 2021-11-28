namespace lw7
{
    /// <summary>
    /// Represents RGBA color
    /// </summary>
    public class RGBAColor : IRGBAColor
    {
        private double _r;
        private double _g;
        private double _b;
        private double _a;

        public double R => _r;
        public double G => _g;
        public double B => _b;
        public double A => _a;

        public RGBAColor( double r, double g, double b, double a )
        {
            _r = r;
            _g = g;
            _b = b;
            _a = a;
        }
    }
}
