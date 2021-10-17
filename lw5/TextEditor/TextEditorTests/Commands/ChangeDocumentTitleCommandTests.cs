using NUnit.Framework;
using TextEditor.Commands;
using TextEditorTests.Mocks;

namespace TextEditorTests.Commands
{
    public class ChangeDocumentTitleCommandTests
    {
        [Test]
        public void ChangeFileNameCommand_CorrectBehaviour()
        {
            //Arrange            
            string b = "b string";
            TestDocument document = new();
            ChangeDocumentTitleCommand command = new( document, b );

            //Act
            command.Invoke();
            string afterInvoke = document.Title;
            bool isExecAfterInvoke = command.IsInvoked;
            command.Undo();
            string afterUndo = document.Title;
            bool isExecAfterUndo = command.IsInvoked;

            //Assert
            Assert.That( afterInvoke, Is.EqualTo( b ) );
            Assert.IsTrue( isExecAfterInvoke );
            Assert.That( afterUndo, Is.EqualTo( null ) );
            Assert.IsFalse( isExecAfterUndo );
        }
    }
}
