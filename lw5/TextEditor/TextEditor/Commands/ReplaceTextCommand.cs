using TextEditor.DocumentItems.Paragraph;

namespace TextEditor.Commands
{
    public class ReplaceTextCommand : AbstractCommand
    {
        private readonly IParagraph _target;
        private string _textTemp;

        public ReplaceTextCommand( IParagraph target, string newText )
            : base()
        {
            _target = target;
            _textTemp = newText;
        }

        protected override void DoInvoke()
        {
            base.DoInvoke();
            var temp = _target.Text;
            _target.Text = _textTemp;
            _textTemp = temp;
        }

        protected override void DoUndo()
        {
            base.DoUndo();
            var temp = _target.Text;
            _target.Text = _textTemp;
            _textTemp = temp;
        }
    }
}
