using GraphicsLib;
using ModernGraphicsLib;
using ModernPoint = ModernGraphicsLib.Point;

namespace MeDrawer
{
    public class ModernGraphicsRendererAdapter : ICanvas, IDisposable
    {
        private readonly ModernGraphicsRenderer _renderer;

        private ModernPoint _currentPoint = new( 0, 0 );

        public ModernGraphicsRendererAdapter( ModernGraphicsRenderer renderer )
        {
            _renderer = renderer ?? throw new ArgumentNullException( nameof( renderer ) );
            _renderer.BeginDraw();
        }

        public void LineTo( int x, int y )
        {
            _renderer.DrawLine( _currentPoint, new( x, y ) );
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
