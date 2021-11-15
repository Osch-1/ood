using NUnit.Framework;
using ArtDesigner.Primitives;

namespace ArtDesignerTests.PrimitivesTests
{
    public class PointTests
    {
        [Test]
        public void Point_Equals_EqualAndUpcastedToObjectPoint_ReturnTrue()
        {
            //Arrange
            Point point = new( 1, 1 );
            object objPoint = new Point( 1, 1 );

            //Act
            bool result = point.Equals( objPoint );

            //Assert
            Assert.That( result, Is.True );
        }

        [Test]
        public void Point_Equals_NotEqualUpcastedToObjectPoint_ReturnFalse()
        {
            //Arrange
            Point point = new( 1, 1 );
            object objPoint = new Point( 2, 2 );

            //Act
            bool result = point.Equals( objPoint );

            //Assert
            Assert.That( result, Is.False );
        }

        [Test]
        public void Point_Equals_EqualPoint_ReturnTrue()
        {
            //Arrange
            Point first = new( 1, 1 );
            Point second = new( 1, 1 );

            //Act
            bool result = first.Equals( second );

            //Assert
            Assert.That( result, Is.True );
        }

        [Test]
        public void Point_Equals_EqualPoint_ReturnFalse()
        {
            //Arrange
            Point first = new( 1, 1 );
            Point second = new( 2, 2 );

            //Act
            bool result = first.Equals( second );

            //Assert
            Assert.That( result, Is.False );
        }
    }
}
