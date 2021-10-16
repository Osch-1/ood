using System;

namespace ArtDesigner.Shapes
{
    public class RegularPolygon : IShape
    {
        private const int MinVertexCount = 3;
        private const int CompleteAngle = 360;

        private Point _center;
        private int _radius;
        private int _vertexCount;
        private double _angleInRads;
        private Color _color;

        public Point Center
        {
            get => _center;
        }

        public int Radius
        {
            get => _radius;
        }

        public int VertexCount
        {
            get => _vertexCount;
        }


        public Color Color
        {
            get => _color;
        }

        public RegularPolygon( Point center, int radius, int vertexCount, Color color )
        {
            if ( center is null )
                throw new ArgumentException( nameof( center ), "Center point can't be null" );

            if ( radius <= 0 )
                throw new ArgumentException( nameof( radius ), "Radius must be greater than 0" );

            if ( vertexCount <= MinVertexCount )
                throw new ArgumentException( nameof( vertexCount ), "Vertex count must be greater than 3" );

            _center = center;
            _radius = radius;
            _vertexCount = vertexCount;
            _color = color;

            _angleInRads = ConvertToRadians( CompleteAngle / vertexCount );
        }

        public void Draw( ICanvas canvas )
        {
            canvas.SetColor( GetColor() );

            var sourcePoint = GetFirstDrawingPoint();
            var destPoint = RotatePoint( sourcePoint, _center, 90 );
            for ( int i = 0; i < _vertexCount; i++ )
            {
                canvas.DrawLine( sourcePoint, destPoint );
                sourcePoint = destPoint;
                destPoint = RotatePoint( sourcePoint, _center, 90 );
            }
        }

        public Color GetColor()
        {
            return _color;
        }

        public void AddVertex()
        {
            _vertexCount++;
        }

        public void AddVertexes( int count )
        {
            int newVertexCount = _vertexCount + count;
            if ( ( _vertexCount + count ) < 3 )
                throw new ArgumentException( nameof( count ), "Provided number of vertexes to add will create incorrect object" );

            _vertexCount = newVertexCount;
        }

        private Point GetFirstDrawingPoint()
        {
            return new Point( _center.X, _center.Y + _radius );
        }

        private Point RotatePoint( Point p1, Point p2, double angle )
        {
            double radians = -ConvertToRadians( angle );//to rotate in clockwise
            double sin = Math.Sin( radians );
            double cos = Math.Cos( radians );

            // Translate point back to origin
            p1.X -= p2.X;
            p1.Y -= p2.Y;

            // Rotate point
            double xnew = p1.X * cos - p1.Y * sin;
            double ynew = p1.X * sin + p1.Y * cos;

            // Translate point back
            Point newPoint = new( ( int )xnew + p2.X, ( int )ynew + p2.Y );
            return newPoint;
        }

        private double ConvertToRadians( double angle )
        {
            return ( Math.PI / 180 ) * angle;
        }
    }
}
