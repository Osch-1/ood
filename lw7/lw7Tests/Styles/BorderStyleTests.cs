using System;
using lw7;
using lw7.Styles;
using NUnit.Framework;

namespace lw7Tests.Styles
{
    public class BorderStyleTests
    {
        [Test]
        public void BorderStyle_DefaultCtor_CorrectState()
        {
            //Arrange
            BorderStyle style;

            //Act
            style = new();

            //Assert
            Assert.IsNotNull( style );
            Assert.That( style.IsEnabled, Is.True );
            Assert.That( style.Color, Is.EqualTo( new RGBAColor( 0, 0, 0, 1 ) ) );
            Assert.That( style.BorderHeight, Is.EqualTo( 1 ) );
        }

        [Test]
        public void BorderStyle_Disable_DisablesStyle()
        {
            //Arrange
            BorderStyle style = new();

            //Act
            style.Disable();

            //Assert
            Assert.IsFalse( style.IsEnabled );
        }

        [Test]
        public void BorderStyle_Enable_EnablesStyle()
        {
            //Arrange
            BorderStyle style = GetDisabledBorderStyle();

            //Act
            style.Enable();

            //Assert
            Assert.IsTrue( style.IsEnabled );
        }

        [Test]
        public void BorderStyle_SetBorderHeight_ZeroValue_SetsHeightAndDisablesStyle()
        {
            //Arrange
            BorderStyle style = new();

            //Act
            style.BorderHeight = 0;

            //Assert
            Assert.That( style.BorderHeight, Is.EqualTo( 0 ) );
            Assert.That( style.IsEnabled, Is.False );
        }

        [Test]
        public void BorderStyle_SetBorderHeight_PositiveValue_SetsHeight()
        {
            //Arrange
            BorderStyle style = new();

            //Act
            style.BorderHeight = 10;

            //Assert
            Assert.That( style.BorderHeight, Is.EqualTo( 10 ) );
            Assert.That( style.IsEnabled, Is.True );
        }

        [Test]
        public void BorderStyle_SetBorderHeight_NegativeValue_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            BorderStyle style = new();

            //Act
            void a() => style.BorderHeight = -10;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>( a );
        }

        private static BorderStyle GetDisabledBorderStyle()
        {
            BorderStyle style = new();
            style.Disable();
            return style;
        }
    }
}
