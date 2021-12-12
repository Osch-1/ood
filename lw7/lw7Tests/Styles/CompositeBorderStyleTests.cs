using System.Linq;
using lw7;
using lw7.Styles;
using lw7Tests.TestObjects;
using NUnit.Framework;

namespace lw7Tests.Styles
{
    public class CompositeBorderStyleTests
    {
        [Test]
        public void CompositeBorderStyle_IsEnabledGetter_ReturnsTrueIfEachStyleInEnumeratorIsEnabled()
        {
            //Arrange
            SimpleBorderStylesEnumerator stylesEnumerator = SimpleBorderStylesEnumerator.WithEachEnabled();
            CompositeBorderStyle style = new( stylesEnumerator );

            //Act
            bool isEnabled = style.IsEnabled;

            //Assert
            Assert.IsTrue( isEnabled );
        }

        [Test]
        public void CompositeBorderStyle_IsEnabledGetter_ReturnsFalseIfEachStyleInEnumeratorIsDisabled()
        {
            //Arrange
            SimpleBorderStylesEnumerator stylesEnumerator = SimpleBorderStylesEnumerator.WithEachDisabled();
            CompositeBorderStyle style = new( stylesEnumerator );

            //Act
            bool isEnabled = style.IsEnabled;

            //Assert
            Assert.IsFalse( isEnabled );
        }

        [Test]
        public void CompositeBorderStyle_IsEnabledGetter_ReturnsFalseIfAtLeastOneIsDisabled()
        {
            //Arrange
            SimpleBorderStylesEnumerator stylesEnumerator = SimpleBorderStylesEnumerator.WithOneOfThreeDisabled();
            CompositeBorderStyle style = new( stylesEnumerator );

            //Act
            bool isEnabled = style.IsEnabled;

            //Assert
            Assert.IsFalse( isEnabled );
        }

        [Test]
        public void CompositeBorderStyle_Color_CompositeStyleWithEnumeratorWhereEachColorEquals_ReturnsColorOfStyles()
        {
            //Arrange
            SimpleBorderStylesEnumerator stylesEnumerator = SimpleBorderStylesEnumerator.WithSameColor();
            CompositeBorderStyle style = new( stylesEnumerator );

            //Act
            var color = style.Color;

            //Assert
            Assert.IsNotNull( color );
            Assert.That( color.R, Is.EqualTo( 255 ) );
            Assert.That( color.G, Is.EqualTo( 255 ) );
            Assert.That( color.B, Is.EqualTo( 255 ) );
            Assert.That( color.A, Is.EqualTo( 0.5 ) );
        }

        [Test]
        public void CompositeBorderStyle_ColorSetter_RGBA_SetsEachStyleColorToProvided()
        {
            //Arrange
            SimpleBorderStylesEnumerator stylesEnumerator = SimpleBorderStylesEnumerator.WithDifferentColors();
            RGBAColor color = new( 127, 12, 12, 0.3 );
            CompositeBorderStyle style = new( stylesEnumerator );

            //Act
            style.Color = color;

            //Assert
            Assert.IsTrue( stylesEnumerator.BorderStyles.All( s => s.Color.Equals( color ) ) );
        }

        [Test]
        public void CompositeBorderStyle_Enable_WithEachDisabledStyles_EnablesAll()
        {
            //Arrange
            SimpleBorderStylesEnumerator stylesEnumerator = SimpleBorderStylesEnumerator.WithEachDisabled();
            CompositeBorderStyle style = new( stylesEnumerator );

            //Act
            style.Enable();

            //Assert
            Assert.IsTrue( stylesEnumerator.BorderStyles.All( s => s.IsEnabled ) );
        }

        [Test]
        public void CompositeBorderStyle_Disable_WithEachEnabledStyles_DisablesAll()
        {
            //Arrange
            SimpleBorderStylesEnumerator stylesEnumerator = SimpleBorderStylesEnumerator.WithEachEnabled();
            CompositeBorderStyle style = new( stylesEnumerator );

            //Act
            style.Disable();

            //Assert
            Assert.IsFalse( stylesEnumerator.BorderStyles.All( s => s.IsEnabled ) );
        }

        [Test]
        public void CompositeBorderStyle_BorderHeight_WithEnumeratorWhereBorderHeightsAreEqual_ReturnsBorderHeight()
        {
            //Arrange
            SimpleBorderStylesEnumerator stylesEnumerator = SimpleBorderStylesEnumerator.WithSameBorderHeight();
            CompositeBorderStyle style = new( stylesEnumerator );

            //Act
            double height = style.BorderHeight;

            //Assert
            Assert.That( height, Is.EqualTo( 10 ) );
        }

        [Test]
        public void CompositeBorderStyle_BorderHeight_WithEnumeratorWhereBorderHeightsAreNotEqual_ReturnsMinusOne()
        {
            //Arrange
            SimpleBorderStylesEnumerator stylesEnumerator = SimpleBorderStylesEnumerator.WithDifferentBorderHeight();
            CompositeBorderStyle style = new( stylesEnumerator );

            //Act
            double height = style.BorderHeight;

            //Assert
            Assert.That( height, Is.EqualTo( -1 ) );
        }

        [Test]
        public void CompositeBorderStyle_BorderHeightSetter_CorrectValue_SetsEachBorderHeightToProvided()
        {
            //Arrange
            SimpleBorderStylesEnumerator stylesEnumerator = SimpleBorderStylesEnumerator.WithDifferentColors();
            double borderHeight = 12;
            CompositeBorderStyle style = new( stylesEnumerator );

            //Act
            style.BorderHeight = borderHeight;

            //Assert
            Assert.IsTrue( stylesEnumerator.BorderStyles.All( s => s.BorderHeight.Equals( borderHeight ) ) );
        }
    }
}
