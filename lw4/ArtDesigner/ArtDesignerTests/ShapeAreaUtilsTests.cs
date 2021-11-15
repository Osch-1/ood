using NUnit.Framework;
using ArtDesigner.Toolkit;
using ArtDesigner.Primitives;
using System.Collections.Generic;

namespace ArtDesignerTests
{
    public class ShapeAreaUtilsTests
    {
        [Test]
        public void ShapeAreaUtils_GetPolygonArea_ThreePoints_CorrectArea()
        {
            //Arrange
            Point point1 = new( 0, 0 );
            Point point2 = new( 0, 5 );
            Point point3 = new( 5, 0 );

            //Act
            var area = ShapeAreaUtils.GetPolygonArea( new List<Point> { point1, point2, point3 } );

            //Assert
            Assert.That( area, Is.EqualTo( 12.5 ) );
        }
    }
}
