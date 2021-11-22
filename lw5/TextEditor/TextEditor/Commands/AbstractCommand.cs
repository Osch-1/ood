namespace TextEditor.Commands
{
    public abstract class AbstractCommand : ICommand
    {
        private bool _isInvoked = false;

        public bool IsInvoked => _isInvoked;

        public void Invoke()
        {
            if ( !_isInvoked )
            {
                DoInvoke();
                _isInvoked = true;
            }
        }

        public void Undo()
        {
            if ( _isInvoked )
            {
                DoUndo();
                _isInvoked = false;
            }
        }

        protected virtual void DoInvoke()
        {

        }

        protected virtual void DoUndo()
        {

        }
    }
}
