using System;
using ArtDesigner;
using ArtDesigner.Shapes;
using ArtDesignerTests.Fakes.Canvas;
using NUnit.Framework;

namespace ArtDesignerTests
{
    public class RegularPolygonTests
    {
        [Test]
        public void RegularPolygon_Constructor_CorrectValues_ObjectWithProvidedParams()
        {
            //Arrange
            RegularPolygon regularPolygon;

            //Act
            regularPolygon = new( new Point( 0, 0 ), 1, 4, Color.Green );

            //Assert
            Assert.That( regularPolygon.Center.X, Is.EqualTo( 0 ) );
            Assert.That( regularPolygon.Center.Y, Is.EqualTo( 0 ) );
            Assert.That( regularPolygon.VertexCount, Is.EqualTo( 4 ) );
            Assert.That( regularPolygon.Radius, Is.EqualTo( 1 ) );
            Assert.That( regularPolygon.GetColor(), Is.EqualTo( Color.Green ) );
        }

        [Test]
        public void RegularPolygon_Draw_ParametersOfSquare_CorrectCoordsInCallSavingCanvas()
        {
            //Arrange
            RegularPolygon regularPolygon = new( new Point( 0, 0 ), 1, 4, Color.Green );
            CallsSavingCanvas canvas = new();

            //Act            
            regularPolygon.Draw( canvas );

            //Assert
            Assert.That( canvas.SrcToDestLinePointsTuples.Count, Is.EqualTo( 4 ) );
            Assert.That( canvas.SrcToDestLinePointsTuples[ 0 ], Is.EqualTo( new Tuple<Point, Point>( new( 0, 1 ), new( 1, 0 ) ) ) );
            Assert.That( canvas.SrcToDestLinePointsTuples[ 1 ], Is.EqualTo( new Tuple<Point, Point>( new( 1, 0 ), new( 0, -1 ) ) ) );
            Assert.That( canvas.SrcToDestLinePointsTuples[ 2 ], Is.EqualTo( new Tuple<Point, Point>( new( 0, -1 ), new( -1, 0 ) ) ) );
            Assert.That( canvas.SrcToDestLinePointsTuples[ 3 ], Is.EqualTo( new Tuple<Point, Point>( new( -1, 0 ), new( 0, 1 ) ) ) );
        }
    }
}