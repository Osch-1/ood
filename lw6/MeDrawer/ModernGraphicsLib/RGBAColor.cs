namespace ModernGraphicsLib
{
    /// <summary>
    /// Represents RGBA color
    /// </summary>
    public class RGBAColor
    {
        private float _r;
        private float _g;
        private float _b;
        private float _a;

        public float R => _r;
        public float G => _g;
        public float B => _b;
        public float A => _a;

        public RGBAColor( float r, float g, float b, float a )
        {
            _r = r;
            _g = g;
            _b = b;
            _a = a;
        }
    }
}
