using System;

namespace ArtDesigner.Shapes
{
    public class Rectangle : IShape
    {
        private Point _topLeft;
        private int _width;
        private int _height;
        private Color _color;

        public Point TopLeft
        {
            get => _topLeft;
        }
        public Point TopRight
        {
            get => new Point( TopLeft.X + _width, TopLeft.Y );
        }
        public Point BottomLeft
        {
            get => new Point( TopLeft.X, TopLeft.Y - Height );
        }
        public Point BottomRight
        {
            get => new Point( TopLeft.X + _width, TopLeft.Y - Height );
        }
        public int Width
        {
            get => _width;
        }
        public int Height
        {
            get => _height;
        }

        public Rectangle( int topLeftX, int topLeftY, int width, int height, Color color )
        {
            if ( topLeftX < 0 || topLeftY < 0 || width < 0 || height < 0 )
                throw new ArgumentException();

            _topLeft = new Point( topLeftX, topLeftY );
            _width = width;
            _height = height;
            _color = color;
        }

        public void Draw( ICanvas canvas )
        {
            canvas.SetColor( GetColor() );
            canvas.DrawLine( _topLeft, TopRight );
            canvas.DrawLine( TopRight, BottomRight );
            canvas.DrawLine( BottomRight, BottomLeft );
            canvas.DrawLine( BottomLeft, _topLeft );
        }

        public Color GetColor()
        {
            return _color;
        }
    }
}
