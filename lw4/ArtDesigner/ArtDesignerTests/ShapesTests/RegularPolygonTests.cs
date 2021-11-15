using NUnit.Framework;
using ArtDesigner.Shapes;
using ArtDesigner.Primitives;
using ArtDesignerTests.TestObjects;

namespace ArtDesignerTests.ShapesTests
{
    public class RegularPolygonTests
    {
        [Test]
        public void RegularPolygon_Draw_HistoryStoringCanvas_ExpectedHistoryStoredInCanvas()
        {
            //Arrange
            HistoryStoringCanvas canvas = new();
            RegularPolygon polygon = new( Color.Black, new( 0, 0 ), 5, 3 );

            //Act
            polygon.Draw( canvas );

            //Assert
            Assert.That( canvas.History.Count, Is.EqualTo( 4 ) );
        }
    }
}
