using lw7;
using lw7.Shapes;
using NUnit.Framework;
using System.Reflection;

namespace lw7Tests.Shapes
{
    public class EllipseTests
    {
        [Test]
        public void Ellipse_Ctor_CorrectParams_CorrectState()
        {
            //Arrange
            Ellipse ellipse;

            //Act
            ellipse = new( new( 10, 12 ), 20, 30 );

            //Assert
            Assert.NotNull( ellipse );

            var frame = ellipse.Frame;
            Assert.NotNull( frame );
            Assert.That( ellipse.Parent, Is.Null );
            Assert.That( ellipse.Composite, Is.Null );
            Assert.That( ellipse.LeftTop, Is.EqualTo( new Point( 10, 12 ) ) );
            Assert.That( frame.LeftTopX, Is.EqualTo( 10 ) );
            Assert.That( frame.LeftTopY, Is.EqualTo( 12 ) );
            Assert.That( frame.Width, Is.EqualTo( 20 ) );
            Assert.That( frame.Height, Is.EqualTo( 30 ) );
        }

        [Test]
        public void Ellipse_SetFrame_CorrectValues_CorrectState()
        {
            //Arrange
            Ellipse ellipse = new( new( 5, 10 ), 30, 10 );
            Frame frame = new( 7, 12, 50, 20 );

            //Act
            ellipse.SetFrame( frame );

            //Assert
            Assert.That( ellipse.LeftTop, Is.EqualTo( new Point( 7, 12 ) ) );
            Assert.That( ellipse.GetType().GetField( "_width", BindingFlags.NonPublic | BindingFlags.Instance ).GetValue( ellipse ), Is.EqualTo( 50.0 ) );
            Assert.That( ellipse.GetType().GetField( "_height", BindingFlags.NonPublic | BindingFlags.Instance ).GetValue( ellipse ), Is.EqualTo( 20.0 ) );
        }
    }
}