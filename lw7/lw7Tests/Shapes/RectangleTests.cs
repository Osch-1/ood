using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using lw7.Shapes;
using lw7;
using System.Reflection;

namespace lw7Tests.Shapes
{
    public class RectangleTests
    {
        [Test]
        public void Rectangle_Ctor_CorrectParams_CorrectState()
        {
            //Arrange
            Rectangle Rectangle;

            //Act
            Rectangle = new( new( 10, 12 ), 20, 30 );

            //Assert
            Assert.NotNull( Rectangle );

            var frame = Rectangle.Frame;
            Assert.NotNull( frame );
            Assert.That( Rectangle.Parent, Is.Null );
            Assert.That( Rectangle.Composite, Is.Null );
            Assert.That( Rectangle.LeftTop, Is.EqualTo( new Point( 10, 12 ) ) );
            Assert.That( frame.LeftTopX, Is.EqualTo( 10 ) );
            Assert.That( frame.LeftTopY, Is.EqualTo( 12 ) );
            Assert.That( frame.Width, Is.EqualTo( 20 ) );
            Assert.That( frame.Height, Is.EqualTo( 30 ) );
        }

        [Test]
        public void Rectangle_SetFrame_CorrectValues_CorrectState()
        {
            //Arrange
            Rectangle Rectangle = new( new( 5, 10 ), 30, 10 );
            Frame frame = new( 7, 12, 50, 20 );

            //Act
            Rectangle.SetFrame( frame );

            //Assert
            Assert.That( Rectangle.LeftTop, Is.EqualTo( new Point( 7, 12 ) ) );
            Assert.That( Rectangle.GetType().GetField( "_width", BindingFlags.NonPublic | BindingFlags.Instance ).GetValue( Rectangle ), Is.EqualTo( 50.0 ) );
            Assert.That( Rectangle.GetType().GetField( "_height", BindingFlags.NonPublic | BindingFlags.Instance ).GetValue( Rectangle ), Is.EqualTo( 20.0 ) );
        }
    }
}
