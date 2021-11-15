using NUnit.Framework;
using ArtDesigner.Shapes;
using ArtDesigner.Factories;
using ArtDesigner.Primitives;
using System;

namespace ArtDesignerTests.Factories
{
    public class ShapeFactorytests
    {
        //"Ellipse", "Rectangle", "RegularPolygon", "Triangle"

        [Test]
        public void ShapeFactory_CreateShape_EllipseDescription_ReturnsEllipse()
        {
            //Arrange
            var factory = new ShapeFactory();
            string description = "Ellipse Red 2 3 10 10";

            //Act
            IShape shape = factory.CreateShape( description );

            //Assert
            Assert.That( shape.GetType(), Is.EqualTo( typeof( Ellipse ) ) );
            Assert.That( shape.Color, Is.EqualTo( Color.Red ) );
        }

        [Test]
        public void ShapeFactory_CreateShape_RectangleDescription_ReturnsRectangle()
        {
            //Arrange
            var factory = new ShapeFactory();
            string description = "Rectangle Red 0 0 5 5";

            //Act
            IShape shape = factory.CreateShape( description );

            //Assert
            Assert.That( shape.GetType(), Is.EqualTo( typeof( Rectangle ) ) );
            Assert.That( shape.Color, Is.EqualTo( Color.Red ) );
        }

        [Test]
        public void ShapeFactory_CreateShape_RegularPolygonDescription_ReturnsRectangle()
        {
            //Arrange
            var factory = new ShapeFactory();
            string description = "RegularPolygon Red 0 0 5 3";

            //Act
            IShape shape = factory.CreateShape( description );

            //Assert
            Assert.That( shape.GetType(), Is.EqualTo( typeof( RegularPolygon ) ) );
            Assert.That( shape.Color, Is.EqualTo( Color.Red ) );
        }

        [Test]
        public void ShapeFactory_CreateShape_TriangleDescription_ReturnsRectangle()
        {
            //Arrange
            var factory = new ShapeFactory();
            string description = "Triangle Red 0 0 0 5 5 0";

            //Act
            IShape shape = factory.CreateShape( description );

            //Assert
            Assert.That( shape.GetType(), Is.EqualTo( typeof( Triangle ) ) );
            Assert.That( shape.Color, Is.EqualTo( Color.Red ) );
        }

        [Test]
        public void ShapeFactory_CreateShape_NonexistingShapeTypeDescription_ThrowsArgumentException()
        {
            //Arrange
            var factory = new ShapeFactory();
            string description = "SomeType Red 0 0 0 5 5 0";

            //Act
            void CreateShapeByIncorrectDescription()
            {
                factory.CreateShape( description );
            }

            //Assert
            Assert.Throws<ArgumentException>( CreateShapeByIncorrectDescription );
        }

        [Test]
        public void ShapeFactory_CreateShape_TriangleWithIncorrectParamsCount_ThrowsArgumentException()
        {
            //Arrange
            var factory = new ShapeFactory();
            string description = "Triangle Red 0 0 0 5";

            //Act
            void CreateShapeByIncorrectDescription()
            {
                factory.CreateShape( description );
            }

            //Assert
            Assert.Throws<ArgumentException>( CreateShapeByIncorrectDescription );
        }

        [Test]
        public void ShapeFactory_CreateShape_EllipseWithIncorrectParamsCount_ThrowsArgumentException()
        {
            //Arrange
            var factory = new ShapeFactory();
            string description = "Ellipse Red 0 5";

            //Act
            void CreateShapeByIncorrectDescription()
            {
                factory.CreateShape( description );
            }

            //Assert
            Assert.Throws<ArgumentException>( CreateShapeByIncorrectDescription );
        }

        [Test]
        public void ShapeFactory_CreateShape_RectangleWithIncorrectParamsCount_ThrowsArgumentException()
        {
            //Arrange
            var factory = new ShapeFactory();
            string description = "Rectangle Red 0 5";

            //Act
            void CreateShapeByIncorrectDescription()
            {
                factory.CreateShape( description );
            }

            //Assert
            Assert.Throws<ArgumentException>( CreateShapeByIncorrectDescription );
        }

        [Test]
        public void ShapeFactory_CreateShape_RegularPolygonWithIncorrectParamsCount_ThrowsArgumentException()
        {
            //Arrange
            var factory = new ShapeFactory();
            string description = "RegularPolygon Red 0 5";

            //Act
            void CreateShapeByIncorrectDescription()
            {
                factory.CreateShape( description );
            }

            //Assert
            Assert.Throws<ArgumentException>( CreateShapeByIncorrectDescription );
        }
    }
}
