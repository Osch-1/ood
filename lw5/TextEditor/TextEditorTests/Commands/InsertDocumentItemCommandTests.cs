using System.Collections.Generic;
using NUnit.Framework;
using TextEditor.Commands;
using TextEditor.DocumentItems;
using TextEditor.DocumentItems.Paragraph;

namespace TextEditorTests.Commands
{
    public class InsertDocumentItemCommandTests
    {
        [Test]
        public void InsertParagraphCommand_Invoke()
        {
            //Arrange
            List<IDocumentItem> items = new List<IDocumentItem>
            {
                new DocumentItem( new Paragraph( "big box" ) ),
                new DocumentItem( new Paragraph( "big box" ) ),
                new DocumentItem( new Paragraph( "big box" ) )
            };

            InsertItemCommand command = new( items, new DocumentItem( new Paragraph( "some text" ) ), 1 );

            //Act
            command.Invoke();

            //Assert
            Assert.That( items.Count, Is.EqualTo( 4 ) );
            Assert.That( items[ 1 ].Paragraph.Text, Is.EqualTo( "some text" ) );
        }

        [Test]
        public void InsertParagraphCommand_InvokeAndUndo()
        {
            //Arrange
            List<IDocumentItem> items = new List<IDocumentItem>
            {
                new DocumentItem( new Paragraph( "big box" ) ),
                new DocumentItem( new Paragraph( "big box" ) ),
                new DocumentItem( new Paragraph( "big box" ) )
            };

            InsertItemCommand command = new( items, new DocumentItem( new Paragraph( "some text" ) ), 1 );

            //Act
            command.Invoke();
            command.Undo();

            //Assert
            Assert.That( items.Count, Is.EqualTo( 3 ) );
            Assert.That( items.TrueForAll( i => i.Paragraph.Text == "big box" ) );
        }
    }
}
