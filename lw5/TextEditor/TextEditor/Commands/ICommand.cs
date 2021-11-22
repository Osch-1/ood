namespace TextEditor.Commands
{
    public interface ICommand
    {
        public bool IsInvoked
        {
            get;
        }

        public void Invoke();

        public void Undo();
    }
}
