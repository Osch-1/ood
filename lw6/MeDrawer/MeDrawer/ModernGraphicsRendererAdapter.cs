using GraphicsLib;
using ModernGraphicsLib;
using ModernPoint = ModernGraphicsLib.Point;

namespace MeDrawer
{
    public class ModernGraphicsRendererAdapter : ICanvas, IDisposable
    {
        private readonly ModernGraphicsRenderer _renderer;

        private RGBAColor _color = new( 0, 0, 0, 1 );
        private ModernPoint _currentPoint = new( 0, 0 );

        public ModernGraphicsRendererAdapter( ModernGraphicsRenderer renderer )
        {
            _renderer = renderer ?? throw new ArgumentNullException( nameof( renderer ) );
            _renderer.BeginDraw();
        }

        public void SetColor( int rgbColor )
        {
            if ( rgbColor < 0 )
            {
                throw new ArgumentOutOfRangeException( nameof( rgbColor ) );
            }

            _color = new RGBAColor( ( rgbColor >> 16 ) & 0xff, ( rgbColor >> 8 ) & 0xff, rgbColor & 0xff, 1 );
        }

        public void LineTo( int x, int y )
        {
            _renderer.DrawLine( _currentPoint, new( x, y ), _color );
            MoveTo( x, y );
        }

        public void MoveTo( int x, int y )
        {
            _currentPoint.X = x;
            _currentPoint.Y = y;
        }

        public void Dispose()
        {
            _renderer.EndDraw();
            _currentPoint = null;

            GC.SuppressFinalize( this );
        }
    }
}
