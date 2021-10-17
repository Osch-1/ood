using System;
using System.IO;
using NUnit.Framework;
using TextEditor;
using TextEditor.DocumentItems.Image;

namespace TextEditorTests.DocumentItems
{
    public class ImageTests
    {
        [SetUp]
        public void Setup()
        {
            TextEditorSettings.InitializeWorkingDirectories();
        }

        [Test]
        public void Image_Ctor_NullPath_ThrowArgumentNullException()
        {
            //Arrange            

            //Act
            void CreateImageWithNullPath()
            {
                new Image( 0, 0, null );
            }

            //Assert
            Assert.Throws<ArgumentNullException>( CreateImageWithNullPath );
        }

        [Test]
        public void Image_Ctor_EmptyPath_ThrowArgumentException()
        {
            //Arrange            

            //Act
            void CreateImageWithEmptyPath()
            {
                new Image( 0, 0, "" );
            }

            //Assert
            Assert.Throws<ArgumentException>( CreateImageWithEmptyPath );
        }

        [Test]
        public void Image_Ctor_NegativeWidth_ThrowArgumentException()
        {
            //Arrange            

            //Act
            void CreateImageWithNullPath()
            {
                new Image( -1, 0, GetExistingImagePath() );
            }

            //Assert
            Assert.Throws<ArgumentException>( CreateImageWithNullPath );
        }

        [Test]
        public void Image_Ctor_NegativeHeight_ThrowArgumentException()
        {
            //Arrange            

            //Act
            void CreateImageWithNegativeHeight()
            {
                new Image( 10, -12, GetExistingImagePath() );
            }

            //Assert
            Assert.Throws<ArgumentException>( CreateImageWithNegativeHeight );
        }

        [Test]
        public void Image_Ctor_OutOfRangeWidth_ThrowArgumentOutOfRangeException()
        {
            //Arrange            

            //Act
            void CreateImageWithNullPath()
            {
                new Image( 100001, 0, GetExistingImagePath() );
            }

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>( CreateImageWithNullPath );
        }

        [Test]
        public void Image_Ctor_OutOfRangeheight_ThrowArgumentOutOfRangeException()
        {
            //Arrange            

            //Act
            void CreateImageWithNegativeHeight()
            {
                new Image( 10, 100000, GetExistingImagePath() );
            }

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>( CreateImageWithNegativeHeight );
        }

        [Test]
        public void Image_Ctor_CorrectParameters_CreateImageWithProvidedParamsAndSaveItInTempDirectoryAndSrcImageStillExists()
        {
            //Arrange
            Image mountain;

            //Act            
            mountain = new Image( 384, 216, GetExistingImagePath() );

            //Assert
            Assert.That( File.Exists( GetExistingImagePath() ), Is.True );

            Assert.That( File.Exists( mountain.Path ), Is.True );
            Assert.That( mountain.Width, Is.EqualTo( 384 ) );
            Assert.That( mountain.Height, Is.EqualTo( 216 ) );
            Assert.That( System.Drawing.Image.FromFile( mountain.Path ).Width, Is.EqualTo( 384 ) );
            Assert.That( System.Drawing.Image.FromFile( mountain.Path ).Height, Is.EqualTo( 216 ) );
        }

        [Test]
        public void Image_Resize_CorrectParameters_CorrectResize()
        {
            //Arrange
            Image mountain = new Image( 3840, 2160, GetExistingImagePath() );

            //Act            
            mountain.Resize( 384, 216 );

            //Assert
            Assert.That( File.Exists( GetExistingImagePath() ), Is.True );

            Assert.That( File.Exists( mountain.Path ), Is.True );
            Assert.That( mountain.Width, Is.EqualTo( 384 ) );
            Assert.That( mountain.Height, Is.EqualTo( 216 ) );
            Assert.That( System.Drawing.Image.FromFile( mountain.Path ).Width, Is.EqualTo( 384 ) );
            Assert.That( System.Drawing.Image.FromFile( mountain.Path ).Height, Is.EqualTo( 216 ) );
        }

        private string GetExistingImagePath()
        {
            return @"C:\Users\daniil.gerasimov\MyDocs\Учеба\3_stage\ood less than 3\ood\lw5\TextEditor\TextEditor\Assets\mountain.jpg";
        }
    }
}