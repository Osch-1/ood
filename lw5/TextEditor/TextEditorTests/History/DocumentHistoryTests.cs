using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TextEditor.Commands;
using TextEditor.History;
using TextEditorTests.Extensions;
using TextEditorTests.Mocks;

namespace TextEditorTests.History
{
    public class DocumentHistoryTests
    {
        [Test]
        public void History_AddAndExecuteCommand_InvokeTrackingCommand_CommandExecutedAndRedoUndoSettedCorrectly()
        {
            //Arrange
            InvokeTrackingCommand command = new InvokeTrackingCommand();
            DocumentHistory history = new();

            //Act
            history.AddAndExecuteCommand( command );

            //Assert
            Assert.That( command.InvokationCount, Is.EqualTo( 1 ) );
            Assert.That( history.CanUndo, Is.True );
            Assert.That( history.CanRedo, Is.False );
        }

        [Test]
        public void History_DoUndoBehaviour_InvokeTrackingCommand_CommandExecutedAndRedoUndoSettedCorrectly()
        {
            //Arrange
            InvokeTrackingCommand command = new InvokeTrackingCommand();
            DocumentHistory history = new();

            //Act
            history.AddAndExecuteCommand( command );
            history.Undo();

            //Assert
            Assert.That( command.InvokationCount, Is.EqualTo( 1 ) );
            Assert.That( command.UndoCount, Is.EqualTo( 1 ) );
            Assert.That( history.CanUndo, Is.False );
            Assert.That( history.CanRedo, Is.True );
            Assert.That( history.GetFieldValue<DocumentHistory, int>( "_nextCommandIndex" ), Is.EqualTo( 0 ) );
        }

        [Test]
        public void History_DoUndoBehaviourWith2Commands_InvokeTrackingCommands_CorrectStateWithOneUndo()
        {
            //Arrange
            InvokeTrackingCommand command1 = new InvokeTrackingCommand();
            InvokeTrackingCommand command2 = new InvokeTrackingCommand();
            DocumentHistory history = new();

            //Act
            history.AddAndExecuteCommand( command1 );
            history.AddAndExecuteCommand( command2 );
            history.Undo();

            //Assert
            Assert.That( command1.InvokationCount, Is.EqualTo( 1 ) );
            Assert.That( command2.InvokationCount, Is.EqualTo( 1 ) );
            Assert.That( command1.UndoCount, Is.EqualTo( 0 ) );
            Assert.That( command2.UndoCount, Is.EqualTo( 1 ) );
            Assert.That( history.CanUndo, Is.True );
            Assert.That( history.CanRedo, Is.True );
            Assert.That( history.GetFieldValue<DocumentHistory, int>( "_nextCommandIndex" ), Is.EqualTo( 1 ) );
        }

        [Test]
        public void History_DoUndoBehaviourWith2Commands_InvokeTrackingCommands_CorrectStateWithTwoUndo()
        {
            //Arrange
            InvokeTrackingCommand command1 = new InvokeTrackingCommand();
            InvokeTrackingCommand command2 = new InvokeTrackingCommand();
            DocumentHistory history = new();

            //Act
            history.AddAndExecuteCommand( command1 );
            history.AddAndExecuteCommand( command2 );
            history.Undo();
            history.Undo();

            //Assert
            Assert.That( command1.InvokationCount, Is.EqualTo( 1 ) );
            Assert.That( command2.InvokationCount, Is.EqualTo( 1 ) );
            Assert.That( command1.UndoCount, Is.EqualTo( 1 ) );
            Assert.That( command2.UndoCount, Is.EqualTo( 1 ) );
            Assert.That( history.CanUndo, Is.False );
            Assert.That( history.CanRedo, Is.True );
            Assert.That( history.GetFieldValue<DocumentHistory, int>( "_nextCommandIndex" ), Is.EqualTo( 0 ) );
        }

        [Test]
        public void History_DoUndoBehaviourWith2Commands_InvokeTrackingCommands_CorrectStateWithTwoUndoAndRedo()
        {
            //Arrange
            InvokeTrackingCommand command1 = new InvokeTrackingCommand();
            InvokeTrackingCommand command2 = new InvokeTrackingCommand();
            DocumentHistory history = new();

            //Act
            history.AddAndExecuteCommand( command1 );
            history.AddAndExecuteCommand( command2 );
            history.Undo();
            history.Undo();
            history.Redo();

            //Assert
            Assert.That( command1.InvokationCount, Is.EqualTo( 2 ) );
            Assert.That( command2.InvokationCount, Is.EqualTo( 1 ) );
            Assert.That( command1.UndoCount, Is.EqualTo( 1 ) );
            Assert.That( command2.UndoCount, Is.EqualTo( 1 ) );
            Assert.That( history.CanUndo, Is.True );
            Assert.That( history.CanRedo, Is.True );
            Assert.That( history.GetFieldValue<DocumentHistory, int>( "_nextCommandIndex" ), Is.EqualTo( 1 ) );
        }

        [Test]
        public void History_DoUndoBehaviourWith2Commands_InvokeTrackingCommands_CorrectStateWithTwoUndoAndTwoRedo()
        {
            //Arrange
            InvokeTrackingCommand command1 = new InvokeTrackingCommand();
            InvokeTrackingCommand command2 = new InvokeTrackingCommand();
            DocumentHistory history = new();

            //Act
            history.AddAndExecuteCommand( command1 );
            history.AddAndExecuteCommand( command2 );
            history.Undo();
            history.Undo();
            history.Redo();
            history.Redo();

            //Assert
            Assert.That( command1.InvokationCount, Is.EqualTo( 2 ) );
            Assert.That( command2.InvokationCount, Is.EqualTo( 2 ) );
            Assert.That( command1.UndoCount, Is.EqualTo( 1 ) );
            Assert.That( command2.UndoCount, Is.EqualTo( 1 ) );
            Assert.That( history.CanUndo, Is.True );
            Assert.That( history.CanRedo, Is.False );
            Assert.That( history.GetFieldValue<DocumentHistory, int>( "_nextCommandIndex" ), Is.EqualTo( 2 ) );
        }

        [Test]
        public void History_DoUndoBehaviourWith2Commands_InvokeTrackingCommands_CorrectStateWithTwoUndoAndAddCommandAfterOneRedo()
        {
            //Arrange
            InvokeTrackingCommand command1 = new InvokeTrackingCommand();
            InvokeTrackingCommand command2 = new InvokeTrackingCommand();
            InvokeTrackingCommand command3 = new InvokeTrackingCommand();
            DocumentHistory history = new();

            //Act
            history.AddAndExecuteCommand( command1 );
            history.AddAndExecuteCommand( command2 );
            history.Undo();
            history.Undo();
            history.Redo();
            history.AddAndExecuteCommand( command3 );

            //Assert
            Assert.That( command1.InvokationCount, Is.EqualTo( 2 ) );
            Assert.That( command2.InvokationCount, Is.EqualTo( 1 ) );
            Assert.That( command3.InvokationCount, Is.EqualTo( 1 ) );
            Assert.That( command1.UndoCount, Is.EqualTo( 1 ) );
            Assert.That( command2.UndoCount, Is.EqualTo( 1 ) );
            Assert.That( command3.UndoCount, Is.EqualTo( 0 ) );
            Assert.That( history.CanUndo, Is.True );
            Assert.That( history.CanRedo, Is.False );
            Assert.That( history.GetFieldValue<DocumentHistory, int>( "_nextCommandIndex" ), Is.EqualTo( 2 ) );

            var commands = history.GetFieldValue<DocumentHistory, List<ICommand>>( "_commands" );
            Assert.That( commands.Count, Is.EqualTo( 2 ) );
            Assert.That( commands.Contains( command2 ), Is.False );

            var firstCommand = commands[ 0 ];
            var lastCommand = commands.Last();
            Assert.IsTrue( ReferenceEquals( firstCommand, command1 ) );
            Assert.IsTrue( ReferenceEquals( lastCommand, command3 ) );            
        }
    }
}
