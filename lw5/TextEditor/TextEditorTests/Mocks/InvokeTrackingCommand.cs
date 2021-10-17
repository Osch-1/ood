using TextEditor.Commands;

namespace TextEditorTests.Mocks
{
    public class InvokeTrackingCommand : AbstractCommand
    {
        public static int _constructedTimesCount = 0;        
        
        public int InvokationCount = 0;
        public int UndoCount = 0;
        public int? Id = null;

        public InvokeTrackingCommand()
        {
            _constructedTimesCount++;
            Id = _constructedTimesCount;
        }

        protected override void DoInvoke()
        {
            base.DoInvoke();
            InvokationCount++;
        }

        protected override void DoUndo()
        {
            base.DoUndo();
            UndoCount++;
        }
    }
}
