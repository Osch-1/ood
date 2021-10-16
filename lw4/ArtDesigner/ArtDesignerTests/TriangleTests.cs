using ArtDesigner;
using NUnit.Framework;
using ArtDesigner.Shapes;

namespace ArtDesignerTests
{
    public class TriangleTests
    {
        [Test]
        public void Triangle_Constructor_CorrectValues_ObjectWithProvidedValues()
        {
            //Arrange
            Triangle triangle;

            //Act
            triangle = new( new Point( 0, 0 ), new Point( 10, 10 ), new Point( 12, 12 ), Color.Black );

            //Assert
            Assert.That( triangle.FirstVertex, Is.EqualTo( new Point( 0, 0 ) ) );
            Assert.That( triangle.SecondVertex, Is.EqualTo( new Point( 10, 10 ) ) );
            Assert.That( triangle.ThirdVertex, Is.EqualTo( new Point( 12, 12 ) ) );
        }
    }
}
