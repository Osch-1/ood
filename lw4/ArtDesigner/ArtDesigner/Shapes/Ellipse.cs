using System;
using ArtDesigner.Canvas;
using ArtDesigner.Primitives;

namespace ArtDesigner.Shapes
{
    public class Ellipse : Shape
    {
        private Point _center;
        private int _horizontalRadius;
        private int _verticalRadius;

        public Ellipse( Color color, Point center, int horizontalRadius, int verticalRadius )
            : base( color )
        {
            if ( horizontalRadius <= 0 )
            {
                throw new ArgumentOutOfRangeException( nameof( horizontalRadius ) );
            }

            if ( verticalRadius <= 0 )
            {
                throw new ArgumentOutOfRangeException( nameof( verticalRadius ) );
            }

            _center = center;
            _horizontalRadius = horizontalRadius;
            _verticalRadius = verticalRadius;
        }

        public Point Center
        {
            get => _center;
        }

        public int HorizontalRadius
        {
            get => _horizontalRadius;
        }

        public int VerticalRadius
        {
            get => _verticalRadius;
        }

        public override void Draw( ICanvas canvas )
        {
            canvas.SetPenColor( Color );
            canvas.DrawEllipse( Center, HorizontalRadius, VerticalRadius );
        }
    }
}
