using System.Text;

namespace TextEditor.Commands
{
    public class ChangeDocumentTitleCommand : AbstractCommand
    {
        private readonly IDocument _document;
        private string _swapped;

        public ChangeDocumentTitleCommand( IDocument document, string newValue )
            : base()
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
