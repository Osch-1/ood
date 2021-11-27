using GraphicsLib;
using ModernGraphicsLib;
using ModernPoint = ModernGraphicsLib.Point;

namespace MeDrawer
{
    public class ModernGraphicsRendererClassAdapter : ModernGraphicsRenderer, ICanvas
    {
        private ModernPoint _currentPoint = new( 0, 0 );

        public ModernGraphicsRendererClassAdapter( Stream stream )
            : base( stream )
        {
            BeginDraw();
        }

        public void LineTo( int x, int y )
        {
            DrawLine( _currentPoint, new( x, y ) );
            MoveTo( x, y );
        }

        public void MoveTo( int x, int y )
        {
            _currentPoint.X = x;
            _currentPoint.Y = y;
        }
    }
}
