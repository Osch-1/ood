using System;
using ArtDesigner.Canvas;
using ArtDesigner.Primitives;

namespace ArtDesigner.Shapes
{
    public class RegularPolygon : Shape
    {
        private Point _center;
        private int _radius;
        private int _vertexCount;

        public Point Center => _center;
        public int Radius => _radius;
        public int VertexCount => _vertexCount;

        public RegularPolygon( Color color, Point center, int radius, int vertexCount )
            : base( color )
        {
            if ( radius < 0 )
            {
                throw new ArgumentOutOfRangeException( nameof( radius ) );
            }

            if ( vertexCount < 3 )
            {
                throw new ArgumentOutOfRangeException( nameof( vertexCount ) );
            }

            _center = center;
            _radius = radius;
            _vertexCount = vertexCount;
        }

        public override void Draw( ICanvas canvas )
        {
            canvas.SetPenColor( Color );

            var angle = 2 * Math.PI / VertexCount;

            Point firstPoint = new( Center.X, Center.Y + Radius );
            Point currentPoint = new( Center.X, Center.Y + Radius );
            Point destPoint = new();
            for ( int i = 1; i < VertexCount; i++ )
            {
                destPoint.X = Math.Cos( angle ) * ( currentPoint.X - Center.X ) - Math.Sin( angle ) * ( currentPoint.Y - Center.Y ) + Center.X;
                destPoint.Y = Math.Sin( angle ) * ( currentPoint.X - Center.X ) + Math.Cos( angle ) * ( currentPoint.Y - Center.Y ) + Center.Y;

                canvas.DrawLine( currentPoint, destPoint );
                currentPoint = destPoint;
            }

            canvas.DrawLine( destPoint, firstPoint );
        }
    }
}
