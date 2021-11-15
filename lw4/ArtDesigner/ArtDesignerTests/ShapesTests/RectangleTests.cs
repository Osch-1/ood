using NUnit.Framework;
using ArtDesigner.Shapes;
using ArtDesigner.Primitives;
using ArtDesignerTests.TestObjects;

namespace ArtDesignerTests.ShapesTests
{
    public class RectangleTests
    {
        [Test]
        public void Rectangle_Draw_HistoryStoringCanvas_InCanvasHistoryStoredExpectedInfo()
        {
            //Arrange
            HistoryStoringCanvas canvas = new();
            Rectangle rectangle = new( Color.Black, new Point( 0, 1 ), 1, 1 );

            //Act
            rectangle.Draw( canvas );

            //Assert
            Assert.That( canvas.History.Count, Is.EqualTo( 5 ) );
        }
    }
}
