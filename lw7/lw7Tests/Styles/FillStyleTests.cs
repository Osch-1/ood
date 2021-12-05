using lw7;
using lw7.Styles;
using NUnit.Framework;

namespace lw7Tests.Styles
{
    public class FillStyleTests
    {
        [Test]
        public void FillStyle_DefaultCtor_CorrectState()
        {
            //Arrange
            FillStyle style;
            RGBAColor expectedColor = new( 0, 0, 0, 1 );

            //Act
            style = new();

            //Assert
            Assert.IsNotNull( style );
            Assert.That( style.IsEnabled, Is.True );
            Assert.That( style.Color, Is.EqualTo( expectedColor ) );
        }

        [Test]
        public void FillStyle_Disable_DisablesStyle()
        {
            //Arrange
            FillStyle style = new();

            //Act
            style.Disable();

            //Assert
            Assert.IsFalse( style.IsEnabled );
        }

        [Test]
        public void FillStyle_Enable_EnablesStyle()
        {
            //Arrange
            FillStyle style = GetDisabledFillStyle();

            //Act
            style.Enable();

            //Assert
            Assert.IsTrue( style.IsEnabled );
        }

        private static FillStyle GetDisabledFillStyle()
        {
            FillStyle style = new();
            style.Disable();
            return style;
        }
    }
}
