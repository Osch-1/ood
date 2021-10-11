using NUnit.Framework;
using TextEditor.Commands;
using TextEditor.History;

namespace TextEditorTests
{
    public class HistoryTests
    {
        [Test]
        public void History_AddAndExecuteCommand_InvokeTrackingCommand_CommandExecutedAndRedoUndoSettedCorrectly()
        {
            //Arrange
            ICommand command = new InvokeTrackingCommand();
            DocumentHistory history = new();

            //Act
            history.AddAndExecuteCommand( command );

            //Assert
            Assert.That( InvokeTrackingCommand.InvokationCount, Is.EqualTo( 1 ) );
            Assert.That( history.CanUndo, Is.True );
            Assert.That( history.CanRedo, Is.False );
        }

        public class InvokeTrackingCommand : AbstractCommand
        {
            public static int InvokationCount = 0;

            protected override void DoInvoke()
            {
                base.DoInvoke();
                InvokationCount++;
            }
        }
    }
}
