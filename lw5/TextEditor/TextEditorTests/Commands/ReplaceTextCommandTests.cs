using NUnit.Framework;
using TextEditor.Document;
using TextEditor.DocumentItems.Paragraph;
using TextEditor.History;

namespace TextEditorTests.Commands
{
    public class ReplaceTextCommandTests
    {
        [Test]
        public void ReplaceTextCommand_BehaviourTest()
        {
            //Arramge
            DocumentHistory history = new();
            Document document = new( history );
            document.InsertParagraph( "some text" );
            var item = document.GetItem( 0 );

            //Act
            IParagraph paragraph = item.Paragraph;

            //Assert

        }
    }
}
