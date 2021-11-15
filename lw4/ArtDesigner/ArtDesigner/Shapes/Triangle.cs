using System;
using ArtDesigner.Canvas;
using ArtDesigner.Toolkit;
using ArtDesigner.Primitives;
using System.Collections.Generic;

namespace ArtDesigner.Shapes
{
    public class Triangle : Shape
    {
        private Point _firstVertex;
        private Point _secondVertex;
        private Point _thirdVertex;

        public Point FirstVertex
        {
            get => _firstVertex;
            set => _firstVertex = value;
        }

        public Point SecondVertex
        {
            get => _secondVertex;
            set => _secondVertex = value;
        }

        public Point ThirdVertex
        {
            get => _thirdVertex;
            set => _thirdVertex = value;
        }

        public Triangle( Color color, Point firstVertex, Point secondVertex, Point thirdVertex )
            : base( color )
        {
            if ( ShapeAreaUtils.GetPolygonArea( new List<Point> { firstVertex, secondVertex, thirdVertex } ) == 0 )
            {
                throw new ArgumentException( "Can't create triangle with such params" );
            }

            _firstVertex = firstVertex;
            _secondVertex = secondVertex;
            _thirdVertex = thirdVertex;
        }

        public override void Draw( ICanvas canvas )
        {
            canvas.SetPenColor( Color );
            canvas.DrawLine( FirstVertex, SecondVertex );
            canvas.DrawLine( SecondVertex, ThirdVertex );
            canvas.DrawLine( ThirdVertex, FirstVertex );
        }
    }
}
