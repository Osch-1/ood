using System;
using NUnit.Framework;
using TextEditor.DocumentItems.Paragraph;

namespace TextEditorTests
{
    public class ParagrpahTests
    {
        [Test]
        public void Parargaph_Ctor_NullText_ThrowArgumentNullExeption()
        {
            //Arrange

            //Act
            void CreateParagrpahWithNullText()
            {
                new Paragraph( null );
            }

            //Assert
            Assert.Throws<ArgumentNullException>( CreateParagrpahWithNullText );
        }

        [Test]
        public void Parargaph_Ctor_CorrectText_CreateObjectWithProvidedText()
        {
            //Arrange
            string text = "Some text";

            //Act
            Paragraph paragraph = new Paragraph( text );

            //Assert
            Assert.That( paragraph.Text, Is.EqualTo( text ) );
        }

        [Test]
        public void Parargaph_setText_NullText_ThrowArgumentNullExeption()
        {
            //Arrange
            Paragraph paragraph = new Paragraph( "Some text" );

            //Act
            void SetNullText()
            {
                paragraph.Text = null;
            }

            //Assert
            Assert.Throws<ArgumentNullException>( SetNullText );
        }

        [Test]
        public void Parargaph_setText_CorrectText_SetProvidedText()
        {
            //Arrange
            Paragraph paragraph = new Paragraph( "initial text" );
            string textToSet = "Some text";

            //Act
            paragraph.Text = textToSet;

            //Assert
            Assert.That( paragraph.Text, Is.EqualTo( textToSet ) );
        }
    }
}