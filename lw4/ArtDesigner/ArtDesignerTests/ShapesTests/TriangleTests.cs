using NUnit.Framework;
using ArtDesigner.Shapes;
using ArtDesigner.Primitives;
using ArtDesignerTests.TestObjects;
using System;

namespace ArtDesignerTests.ShapesTests
{
    public class TriangleTests
    {
        [Test]
        public void Triangle_Ctor_PointsThatLayOnOneLine_ThrowArgumentException()
        {
            //Arrange
            Triangle triangle = null;

            //Act
            void CreateTriangle()
            {
                triangle = new( Color.Red, new( 3, 3 ), new( 3, 9 ), new( 3, 0 ) );
            }

            //Assert
            Assert.Throws<ArgumentException>( CreateTriangle );
        }

        [Test]
        public void Triangle_Draw_HistoryStoringCanvas_InCanvasHistoryStoredExpectedInfo()
        {
            //Arrange
            HistoryStoringCanvas canvas = new();
            Triangle triangle = new( Color.Pink, new( 0, 0 ), new( 1, 1 ), new( 0, 1 ) );

            //Act
            triangle.Draw( canvas );

            //Assert
            Assert.That( canvas.History.Count, Is.EqualTo( 4 ) );
            Assert.That( canvas.History[ 0 ], Is.EqualTo( "SetPenColor Pink" ) );
            Assert.That( canvas.History[ 1 ], Is.EqualTo( "DrawLine {0,0}->{1,1}" ) );
            Assert.That( canvas.History[ 2 ], Is.EqualTo( "DrawLine {1,1}->{0,1}" ) );
            Assert.That( canvas.History[ 3 ], Is.EqualTo( "DrawLine {0,1}->{0,0}" ) );
        }
    }
}
