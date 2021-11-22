using TextEditor.Commands;

namespace TextEditor.History
{
    public interface IHistory
    {
        public bool CanUndo
        {
            get;
        }

        public bool CanRedo
        {
            get;
        }

        public void Undo();

        public void Redo();

        public void AddAndExecuteCommand( ICommand command );
    }
}