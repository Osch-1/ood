using System.Collections.Generic;
using TextEditor.DocumentItems;
using TextEditor.Extensions;

namespace TextEditor.Commands
{
    public class DeleteItemCommand : AbstractCommand
    {
        private List<IDocumentItem> _items;
        private IDocumentItem _documentItem;
        private int _index;

        public DeleteItemCommand( List<IDocumentItem> items, int index )
            : base()
        {
            _items = items;
            _index = index;
        }

        protected override void DoInvoke()
        {
            base.DoInvoke();
            _documentItem = _items[ _index ];
            _items.RemoveAt( _index );
            _items.Resize( _items.Count );
        }

        protected override void DoUndo()
        {
            base.DoUndo();
            _items.Insert( _index, _documentItem );
        }
    }
}
