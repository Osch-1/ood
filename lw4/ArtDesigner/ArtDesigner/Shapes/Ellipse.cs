using System;
using ArtDesigner.Canvas;
using ArtDesigner.Primitives;

namespace ArtDesigner.Shapes
{
    public class Ellipse : Shape
    {
        private Point _center;
        private int _width;
        private int _height;

        public Ellipse( Color color, Point center, int width, int height )
            : base( color )
        {
            if ( width <= 0 )
            {
                throw new ArgumentOutOfRangeException( nameof( width ) );
            }

            if ( height <= 0 )
            {
                throw new ArgumentOutOfRangeException( nameof( height ) );
            }

            _center = center;
            _width = width;
            _height = height;
        }

        public Point Center
        {
            get => _center;
        }

        public double HorizontalRadius
        {
            get => _width / 2.0;
        }

        public double VerticalRadius
        {
            get => _height / 2.0;
        }

        public override void Draw( ICanvas canvas )
        {
            canvas.SetPenColor( Color );
            canvas.DrawEllipse( Center, _width, _height );
        }
    }
}
