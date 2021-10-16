using System;
using ArtDesigner;
using ArtDesigner.Shapes;
using ArtDesignerTests.Fakes.Canvas;
using NUnit.Framework;

namespace ArtDesignerTests
{
    public class EllipseTests
    {
        [Test]
        public void Ellipse_Constructor_OrdinalPointWidthHeightColor_ObjectWithProvidedParams()
        {
            //Arrange
            Ellipse ellipse;

            //Act
            ellipse = new( new Point( 0, 0 ), 10, 10, Color.Pink );

            //Assert
            Assert.That( ellipse.TopLeft.X, Is.EqualTo( 0 ) );
            Assert.That( ellipse.TopLeft.Y, Is.EqualTo( 0 ) );
            Assert.That( ellipse.Width, Is.EqualTo( 10 ) );
            Assert.That( ellipse.Height, Is.EqualTo( 10 ) );
            Assert.That( ellipse.GetColor(), Is.EqualTo( Color.Pink ) );
        }

        [Test]
        public void Ellipse_Constructor_NullEqualCentralPoint_ThrowsArgumentException()
        {
            //Arrange
            Ellipse ellipse;

            TestDelegate constructingIncorrectEllipse = () => ellipse = new( null, 10, 10, Color.Pink );

            //Act & Assert
            Assert.Throws<ArgumentException>( constructingIncorrectEllipse );
        }

        [Test]
        public void Ellipse_Constructor_NegativeWidth_ThrowsArgumentException()
        {
            //Arrange
            Ellipse ellipse;

            TestDelegate constructingIncorrectEllipse = () => ellipse = new( new Point( 0, 0 ), -3, 10, Color.Pink );

            //Act & Assert
            Assert.Throws<ArgumentException>( constructingIncorrectEllipse );
        }

        [Test]
        public void Ellipse_Constructor_NegativeHeight_ThrowsArgumentException()
        {
            //Arrange
            Ellipse ellipse;

            TestDelegate constructingIncorrectEllipse = () => ellipse = new( new Point( 0, 0 ), 15, -10, Color.Pink );

            //Act & Assert
            Assert.Throws<ArgumentException>( constructingIncorrectEllipse );
        }

        [Test]
        public void Ellipse_Draw_CallsSavingCanvas_CorrectDrawInfo()
        {
            //Arrange
            CallsSavingCanvas canvas = new();
            Ellipse ellipse = new( new Point( 0, 0 ), 10, 10, Color.Black );

            //Act
            ellipse.Draw( canvas );

            //Assert
            Assert.AreEqual( 2, canvas.CalledMethods.Count );
            Assert.That( canvas.CalledMethods.Count, Is.EqualTo( 2 ) );
            Assert.That( canvas.CalledMethods[ 0 ], Is.EqualTo( "SetColor(color: Black)" ) );
            Assert.That( canvas.CalledMethods[ 1 ], Is.EqualTo( "DrawEllipse(topleft: 0, 0 width: 10 height: 10)" ) );
        }
    }
}