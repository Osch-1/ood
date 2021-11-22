using GraphicsLib;

namespace ShapeDrawingLib
{
    public class CanvasPainter
    {
        private readonly ICanvas _canvas;

        public CanvasPainter( ICanvas canvas )
        {
            _canvas = canvas ?? throw new ArgumentNullException( nameof( canvas ) );
        }

        public void Draw( ICanvasDrawable drawable )
        {
            if ( _canvas is not null )
            {
                drawable.Draw( _canvas );
            }
        }
    }
}