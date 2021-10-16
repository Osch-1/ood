using System;

namespace ArtDesigner.Shapes
{
    public class Ellipse : IShape
    {
        private Point _topLeft;
        private int _width;
        private int _height;
        private Color _color;

        public Point TopLeft { get => _topLeft; }
        public int Width { get => _width; }
        public int Height { get => _height; }

        public Ellipse( Point topLeft, int width, int height, Color color )
        {
            if ( topLeft is null )
                throw new ArgumentException( "Top left point can't be null", nameof( topLeft ) );

            if ( width < 0 )
                throw new ArgumentException( "Width must be greater or equal to 0", nameof( width ) );

            if ( height < 0 )
                throw new ArgumentException( "Height must be greater or equal to 0", nameof( height ) );

            _topLeft = topLeft;
            _width = width;
            _height = height;
            _color = color;
        }

        public void Draw( ICanvas canvas )
        {
            canvas.SetColor( GetColor() );
            canvas.DrawEllipse( _topLeft, _width, _height );
        }

        public Color GetColor()
        {
            return _color;
        }
    }
}
