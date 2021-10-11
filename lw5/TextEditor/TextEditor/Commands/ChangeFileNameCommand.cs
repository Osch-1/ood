using System.Text;

namespace TextEditor.Commands
{
    public class ChangeFileNameCommand : AbstractCommand
    {        
        private IDocument _document;
        private string _swapped;

        public ChangeFileNameCommand( IDocument document, string newValue )
        {
            _document = document;
            _swapped = newValue;
        }

        protected override void DoInvoke()
        {
            base.DoInvoke();
            string temp = _swapped;
            _swapped = _document.Title;
            _document.Title = temp;
        }

        protected override void DoUndo()
        {
            base.DoUndo();
            string temp = _swapped;
            _swapped = _document.Title;
            _document.Title = temp;
        }
    }
}
