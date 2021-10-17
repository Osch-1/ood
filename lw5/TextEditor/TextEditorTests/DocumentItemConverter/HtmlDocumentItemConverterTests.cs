using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using TextEditor;
using TextEditor.Converters.DocumentItemsConverter;
using TextEditor.DocumentItems;
using TextEditor.DocumentItems.Image;
using TextEditor.DocumentItems.Paragraph;
using TextEditorTests.Extensions;

namespace TextEditorTests.DocumentItemConverter
{
    public class HtmlDocumentItemConverterTests
    {
        [SetUp]
        public void Setup()
        {
            TextEditorSettings.InitializeWorkingDirectories();
        }

        [Test]
        public void HtmlDocumentItemConverter_Convert_ListOfDocumentItems_CorrectConvert()
        {
            //Arrange
            Image image = new Image( 384, 216, GetExistingImagePath() );
            image.SetField( "_path", "images/name" );
            IParagraph paragraph = new Paragraph( "\"&&<< >> \'" );
            IDocumentItemConverter converter = new HtmlDocumentItemsConverter();
            IDocumentItem imageItem = new DocumentItem( image );
            IDocumentItem paragraphItem = new DocumentItem( paragraph );

            //Act
            var convertedResult = converter.Convert( new List<IDocumentItem> { imageItem, paragraphItem } );

            //Assert
            Assert.That( convertedResult, Is.EqualTo( "<img src=\"images/name\" width=\"384\" height=\"216\"><p>&quot;&amp;&amp;&lt;&lt; &gt;&gt; &bsol;</p>" ) );
        }

        private string GetExistingImagePath()
        {
            return @"C:\Users\daniil.gerasimov\MyDocs\Учеба\3_stage\ood less than 3\ood\lw5\TextEditor\TextEditor\Assets\mountain.jpg";
        }
    }
}
