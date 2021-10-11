using System.Collections.Generic;
using TextEditor.Commands;
using TextEditor.Extensions;

namespace TextEditor.History
{
    public class DocumentHistory : IHistory
    {
        private List<ICommand> _commands = new();

        private int _nextCommandIndex = 0;

        public bool CanUndo
        {
            get
            {
                return _nextCommandIndex > 0;
            }
        }

        public bool CanRedo
        {
            get
            {
                return _nextCommandIndex < _commands.Count;
            }
        }

        public void AddAndExecuteCommand( ICommand command )
        {
            _commands.Add( null );

            if ( _commands.Count > _nextCommandIndex )
            {
                command.Invoke();
                _nextCommandIndex++;
                _commands.Resize( _nextCommandIndex );
                _commands[ ^1 ] = command;
            }
            else
            {
                try
                {
                    command.Invoke();
                    _nextCommandIndex++;
                    _commands[ ^1 ] = command;
                }
                catch
                {
                    _commands.RemoveAt( _commands.Count - 1 );
                    throw;
                }
            }
        }

        public void Redo()
        {
            if ( CanRedo )
                _commands[ _nextCommandIndex ].Invoke();

            ++_nextCommandIndex;
        }

        public void Undo()
        {
            if ( CanUndo )
                _commands[ _nextCommandIndex - 1 ].Undo();

            --_nextCommandIndex;
        }
    }
}
