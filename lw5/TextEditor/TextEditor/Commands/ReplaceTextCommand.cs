using TextEditor.DocumentItems.Paragraph;

namespace TextEditor.Commands
{
    public class ReplaceTextCommand : AbstractCommand
    {
        private Paragraph _target;
        private string _textTemp;

        public ReplaceTextCommand( Paragraph target, string newText )
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
