using System;
using NUnit.Framework;
using ArtDesigner.Shapes;
using ArtDesigner.Factories;
using ArtDesigner.Primitives;

namespace ArtDesignerTests.Factories
{
    public class GlyphFactoryTests
    {
        [Test]
        public void ShapeFactory_CreateShape_EllipseDescription_ReturnsEllipse()
        {
            //Arrange
            var factory = new GlyphFactory();
            string description = "Ellipse Red 2 3 10 10";

            //Act
            IGlyph shape = factory.Create( description );

            //Assert
            Assert.That( shape.GetType(), Is.EqualTo( typeof( Ellipse ) ) );
            Assert.That( ( ( Shape )shape ).Color, Is.EqualTo( Color.Red ) );
        }

        [Test]
        public void ShapeFactory_CreateShape_RectangleDescription_ReturnsRectangle()
        {
            //Arrange
            var factory = new GlyphFactory();
            string description = "Rectangle Red 0 0 5 5";

            //Act
            IGlyph shape = factory.Create( description );

            //Assert
            Assert.That( shape.GetType(), Is.EqualTo( typeof( Rectangle ) ) );
            Assert.That( ( shape as Shape ).Color, Is.EqualTo( Color.Red ) );
        }

        [Test]
        public void ShapeFactory_CreateShape_RegularPolygonDescription_ReturnsRectangle()
        {
            //Arrange
            var factory = new GlyphFactory();
            string description = "RegularPolygon Red 0 0 5 3";

            //Act
            IGlyph shape = factory.Create( description );

            //Assert
            Assert.That( shape.GetType(), Is.EqualTo( typeof( RegularPolygon ) ) );
            Assert.That( ( shape as Shape ).Color, Is.EqualTo( Color.Red ) );
        }

        [Test]
        public void ShapeFactory_CreateShape_TriangleDescription_ReturnsRectangle()
        {
            //Arrange
            var factory = new GlyphFactory();
            string description = "Triangle Red 0 0 0 5 5 0";

            //Act
            IGlyph shape = factory.Create( description );

            //Assert
            Assert.That( shape.GetType(), Is.EqualTo( typeof( Triangle ) ) );
            Assert.That( ( shape as Shape ).Color, Is.EqualTo( Color.Red ) );
        }

        [Test]
        public void ShapeFactory_CreateShape_NonexistingShapeTypeDescription_ThrowsArgumentException()
        {
            //Arrange
            var factory = new GlyphFactory();
            string description = "SomeType Red 0 0 0 5 5 0";

            //Act
            void CreateShapeByIncorrectDescription()
            {
                factory.Create( description );
            }

            //Assert
            Assert.Throws<ArgumentException>( CreateShapeByIncorrectDescription );
        }

        [Test]
        public void ShapeFactory_CreateShape_TriangleWithIncorrectParamsCount_ThrowsArgumentException()
        {
            //Arrange
            var factory = new GlyphFactory();
            string description = "Triangle Red 0 0 0 5";

            //Act
            void CreateShapeByIncorrectDescription()
            {
                factory.Create( description );
            }

            //Assert
            Assert.Throws<ArgumentException>( CreateShapeByIncorrectDescription );
        }

        [Test]
        public void ShapeFactory_CreateShape_EllipseWithIncorrectParamsCount_ThrowsArgumentException()
        {
            //Arrange
            var factory = new GlyphFactory();
            string description = "Ellipse Red 0 5";

            //Act
            void CreateShapeByIncorrectDescription()
            {
                factory.Create( description );
            }

            //Assert
            Assert.Throws<ArgumentException>( CreateShapeByIncorrectDescription );
        }

        [Test]
        public void ShapeFactory_CreateShape_RectangleWithIncorrectParamsCount_ThrowsArgumentException()
        {
            //Arrange
            var factory = new GlyphFactory();
            string description = "Rectangle Red 0 5";

            //Act
            void CreateShapeByIncorrectDescription()
            {
                factory.Create( description );
            }

            //Assert
            Assert.Throws<ArgumentException>( CreateShapeByIncorrectDescription );
        }

        [Test]
        public void ShapeFactory_CreateShape_RegularPolygonWithIncorrectParamsCount_ThrowsArgumentException()
        {
            //Arrange
            var factory = new GlyphFactory();
            string description = "RegularPolygon Red 0 5";

            //Act
            void CreateShapeByIncorrectDescription()
            {
                factory.Create( description );
            }

            //Assert
            Assert.Throws<ArgumentException>( CreateShapeByIncorrectDescription );
        }
    }
}
